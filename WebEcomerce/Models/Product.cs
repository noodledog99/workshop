using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebEcomerce.Models
{
    public class Product
    {
        [BsonId]
        public string Id { get; set; }
        [StringLength(50)]
        public string ProductName { get; set; }
        [StringLength(300)]
        public string ProductDetail { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public string ImagePath { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public DateTime? Deleted_at { get; set; }
       
    }

}
