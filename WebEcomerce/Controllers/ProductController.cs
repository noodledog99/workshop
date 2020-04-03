using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demoecomerce.Reponsitories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebEcomerce.Models;

namespace WebEcomerce.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        private Product modelProduct;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
            this.modelProduct = new Product();
        }

        [HttpGet]
        public IEnumerable<Product> GetAllData()
          => productRepository.GetAllProduct();

        [HttpGet]
        public Product GetProductById(string id)
         => productRepository.Get(it => it.Id == id);

        [HttpPost]
        public void AddProduct([FromBody]Product document)
        {
            modelProduct.Id = Guid.NewGuid().ToString();
            modelProduct.ProductName = document.ProductName;
            modelProduct.ProductDetail = document.ProductDetail;
            modelProduct.Price = document.Price;
            modelProduct.Created_at = DateTime.Now;
            productRepository.Create(modelProduct);
        }

        [HttpPost]
        public void EditProduct(Product document)
          => productRepository.Update(document);

        [HttpPost]
        public void DeleteProduct(Product document)
         => productRepository.Delete(document);
    }
}