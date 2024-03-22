using System;
using System.Collections.Generic;

namespace GoeHauWebApp.Models
{
    public partial class Warehouse
    {
        public Warehouse()
        {
            InStocks = new HashSet<InStock>();
            Orders = new HashSet<Order>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public long? Manager { get; set; }

        public virtual User? ManagerNavigation { get; set; }
        public virtual ICollection<InStock> InStocks { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
