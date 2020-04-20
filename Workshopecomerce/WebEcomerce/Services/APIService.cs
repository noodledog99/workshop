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
        private readonly string localhost = "https://localhost:5001/";
        // private readonly string localhost = "https://localhost:44374/";


        public APIService()
        {
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        }

        public List<Product> GetProducts()
        {
            using (var client = new HttpClient(_clientHandler))
            {
                var resultTask = client.GetAsync(localhost + "api/Product/GetProducts");
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
                var postTask = client.PostAsync(localhost + "api/Product/AddProducts", content);
                postTask.Wait();
                result = postTask.Result.IsSuccessStatusCode;
            }
            return result;
        }

        public Product GetProduct(string id)
        {
            using (var client = new HttpClient(_clientHandler))
            {
                var resultTask = client.GetAsync(localhost + "api/Product/GetProductById?id=" + id);
                if (resultTask.Result.IsSuccessStatusCode)
                {
                    var readTask = resultTask.Result.Content.ReadAsAsync<Product>();
                    readTask.Wait();
                    _product = readTask.Result;
                    _product.Created_at = _product.Created_at.Value.ToLocalTime();
                    _product.Updated_at = _product.Updated_at?.ToLocalTime() ?? _product.Updated_at;
                }
            }
            return _product;
        }
    }
}
