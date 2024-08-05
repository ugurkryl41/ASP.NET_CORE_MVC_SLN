using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; } = string.Empty;
        public decimal ProductPrice { get; set; }
        public string? Summary { get; set; } = String.Empty;
        public string? ImageUrl { get; set; }
        public int? CategoryId { get; set; }  //FK Foreign Key
        public Category? Category { get; set; } // Navigation Property
        public bool ShowCase { get; set; }
    }
}
