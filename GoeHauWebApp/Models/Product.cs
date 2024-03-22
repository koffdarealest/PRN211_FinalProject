using System;
using System.Collections.Generic;

namespace GoeHauWebApp.Models
{
    public partial class Product
    {
        public Product()
        {
            InStocks = new HashSet<InStock>();
            Orders = new HashSet<Order>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<InStock> InStocks { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
