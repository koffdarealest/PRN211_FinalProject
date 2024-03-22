using System;
using System.Collections.Generic;

namespace GoeHauWebApp.Models
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
            Trucks = new HashSet<Truck>();
            Warehouses = new HashSet<Warehouse>();
        }

        public long Id { get; set; }
        public byte? Role { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? Fullname { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Truck> Trucks { get; set; }
        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}
