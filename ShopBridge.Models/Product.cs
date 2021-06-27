using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopBridge.Models
{
    public class Product
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }        
    }
}
