using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEcomerce.Models;

namespace Demoecomerce.Services
{
    public class DbService : IDbService
    {
        public IMongoCollection<Product> CollectionProduct { get; set; }
        public IMongoCollection<User> CollectionUser { get; set; }
        public DbService(DbConfig dbConfig)
        {
            var cilent = new MongoClient(dbConfig.MongoDbConnectionString);
            var database = cilent.GetDatabase(dbConfig.MongoDbName);

            CollectionProduct = database.GetCollection<Product>(dbConfig.Product);
            CollectionUser = database.GetCollection<User>(dbConfig.User);
        }
    }
}
