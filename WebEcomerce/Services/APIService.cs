using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebEcomerce.Models;

namespace WebEcomerce.Services
{
    public class APIService
    {
        private readonly HttpClientHandler _clientHandler = new HttpClientHandler();
        private List<Product> _products = new List<Product>();
        private Product _product = new Product();


        public APIService()
        {
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        }

        public List<Product> GetProducts()
        {
            using (var client = new HttpClient(_clientHandler))
            {
                var resultTask = client.GetAsync("https://localhost:44374/api/Product/GetProducts");
                if (resultTask.Result.IsSuccessStatusCode)
                {
                    var readTask = resultTask.Result.Content.ReadAsAsync<List<Product>>();
                    readTask.Wait();
                    _products = readTask.Result.Where(it => it.Deleted_at == null).ToList();
                }
            }
            return _products;
        }

        public bool AddProducts(Product product)
        {
            bool result;
            var test = JsonConvert.SerializeObject(product);
            var content = new StringContent(test, Encoding.UTF8, "application/json");
            using (var client = new HttpClient(_clientHandler))
            {
                var postTask = client.PostAsync("https://localhost:44374/api/Product/AddProducts", content);
                postTask.Wait();
                result = postTask.Result.IsSuccessStatusCode;
            }
            return result;
        }

        public Product GetProduct(string id)
        {
            using (var client = new HttpClient(_clientHandler))
            {
                var resultTask = client.GetAsync("https://localhost:44374/api/Product/GetProductById?id=" + id);
                if (resultTask.Result.IsSuccessStatusCode)
                {
                    var readTask = resultTask.Result.Content.ReadAsAsync<Product>();
                    readTask.Wait();
                    _product = readTask.Result;
                }
            }
            return _product;
        }
    }
}
