using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demoecomerce.Reponsitories;
using Microsoft.AspNetCore.Mvc;
using WebEcomerce.Models;
using System.Web;
using Microsoft.AspNetCore.Http;
using Google.Cloud.Storage.V1;
using System.Net.Http.Headers;
using System.Text;
using System.IO;
using System.Net.Http;
using WebEcomerce.Services;

namespace WebEcomerce.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductRepository productRepository;
        private Product modelProduct = new Product();
        private readonly APIService _apiService;
        public AdminController(IProductRepository productRepository)
        {
            _apiService = new APIService();
            this.productRepository = productRepository;
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", @"D:\Work\Workshopecomerce\WebEcomerce\My First Project-fc65b82dffda.json");
        }

        [HttpGet]
        public IActionResult ManageProduct()
        {
            var products = _apiService.GetProducts();
            return View(products);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(string ProductName, string ProductDetail, double Price, int Amount, IFormFile ImagePath)
        {
            modelProduct.Id = Guid.NewGuid().ToString();
            modelProduct.ProductName = ProductName;
            modelProduct.ProductDetail = ProductDetail;
            modelProduct.Price = Price;
            modelProduct.Amount = Amount;
            modelProduct.ImagePath = UploadFile("storage-image-test", ImagePath);
            modelProduct.Created_at = DateTime.Now;
            var response = _apiService.AddProducts(modelProduct);
            if (response)
            {
                return RedirectToAction("ManageProduct");
            }
            else
            {
                return RedirectToAction("Add");
            }
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            return View(productRepository.Get(it => it.Id == id));
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            product.Updated_at = DateTime.Now;
            productRepository.Update(product);
            return RedirectToAction("ManageProduct");
        }

        [HttpPost]
        public IActionResult DeleteProduct(string id)
        {
            var product = productRepository.Get(it => it.Id == id);
            productRepository.Delete(product);
            return RedirectToAction("ManageProduct");
        }

        [HttpGet]
        public IActionResult Detail(string id)
        {
            return View(productRepository.Get(it => it.Id == id));
        }

        private string UploadFile(string bucketName, IFormFile localPath)
        {
            var time = (int)(DateTime.UtcNow.ToLocalTime() - new DateTime(2020, 1, 1)).TotalSeconds;
            var objectName = $"test/{time.ToString()}.png";
            var storage = StorageClient.Create();
            storage.UploadObject(bucketName, objectName, null, localPath.OpenReadStream());
            var storageObject = storage.GetObject(bucketName, objectName);
            return storageObject.MediaLink;
        }
    }
}