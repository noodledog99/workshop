using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Demoecomerce.Reponsitories;
using Microsoft.AspNetCore.Mvc;
using WebEcomerce.Models;

namespace WebEcomerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository productRepository;
        private Product modelProduct = new Product();

        public HomeController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public List<Product> GetProducts()
            => productRepository.GetAllProduct().Where(it => it.Deleted_at == null).ToList();
        

        public IActionResult Index()
        {
            return View(GetProducts());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
