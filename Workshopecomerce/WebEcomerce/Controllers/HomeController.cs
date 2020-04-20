using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Demoecomerce.Reponsitories;
using Microsoft.AspNetCore.Mvc;
using WebEcomerce.Models;
using WebEcomerce.Services;

namespace WebEcomerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly APIService _apiService;

        public HomeController()
        {
            _apiService = new APIService();
        }

        public IActionResult Index()
        {
            return View(_apiService.GetProducts());
        }

        [HttpGet]
        public IActionResult ViewProduct(string id)
        {
            return View(_apiService.GetProduct(id));
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
