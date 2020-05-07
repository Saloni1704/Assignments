using System;
using System.Collections.Generic;

namespace CustomerApplication.Models
{
    public partial class Products
    {
        public int ProductId { get; set; }
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public int ProductPrice { get; set; }
        public bool ProductStatus { get; set; }
    }
}
