using Demoecomerce.Services;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebEcomerce.Models;

namespace Demoecomerce.Reponsitories
{
    public class ProductRepository : IProductRepository
    {
        public readonly IMongoCollection<Product> Collection;
        public ProductRepository(DbConfig dbCondig)
        {
            var client = new MongoClient(dbCondig.MongoDbConnectionString);
            var database = client.GetDatabase(dbCondig.MongoDbName);
            Collection = database.GetCollection<Product>(dbCondig.Product);

        }
        public void Create(Product document)
          => Collection.InsertOne(document);

        public Product Get(Expression<Func<Product, bool>> expression)
          => Collection.Find(expression).FirstOrDefault();

        public IEnumerable<Product> GetAllProduct()
          => Collection.Find(it => true).ToEnumerable<Product>();

        public void Update(Product document)
        {
            var def = Builders<Product>.Update
                .Set(it => it.ProductName, document.ProductName)
                .Set(it => it.ProductDetail, document.ProductDetail)
                .Set(it => it.Price, document.Price)
                .Set(it => it.Amount, document.Amount)
                .Set(it => it.ImagePath, document.ImagePath)
                .Set(it => it.Updated_at, document.Updated_at);
            Collection.UpdateOne(it => it.Id == document.Id, def);
        }

        public void Delete(Product document)
        {
            var def = Builders<Product>.Update
                .Set(it => it.Deleted_at, DateTime.Now);
            Collection.UpdateOne(it => it.Id == document.Id, def);
        }
    }
}
