using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Product
    {
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public string ProductCategory { get; set; }
        public int ProductStockQuantity { get; set; }
        public string ProductSupplier { get; set; }
    }
}
