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
        [Required(ErrorMessage = "Product Name is required")]
        [StringLength(50)]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Product Detail is required")]
        [StringLength(300)]
        public string ProductDetail { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Amount is required")]
        public int Amount { get; set; }
        public string ImagePath { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public DateTime? Deleted_at { get; set; }

    }

}
