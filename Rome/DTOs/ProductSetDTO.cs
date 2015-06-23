using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rome.Models;

namespace Rome.DTOs
{
    public class ProductSetDTO
    {
        public int ProductSetId { get; set; }
        public string ProductSetDescription { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
