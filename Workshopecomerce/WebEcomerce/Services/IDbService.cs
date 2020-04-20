using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEcomerce.Models;

namespace Demoecomerce.Services
{
    public interface IDbService
    {
        IMongoCollection<Product> CollectionProduct { get; set; }
        IMongoCollection<User> CollectionUser { get; set; }
    }
}
