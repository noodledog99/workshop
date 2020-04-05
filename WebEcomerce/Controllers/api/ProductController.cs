using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demoecomerce.Reponsitories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebEcomerce.Models;

namespace WebEcomerce.Controllers.api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _product;
        public ProductController(IProductRepository product)
        {
            _product = product;
        }

        [HttpGet]
        public List<Product> GetProducts()
            => _product.GetAllProduct().ToList();

        [HttpGet]
        public Product GetProductById(string id)
            => _product.Get(it => it.Id == id);

        [HttpPost]
        public void AddProducts(Product product)
            => _product.Create(product);
    }
}