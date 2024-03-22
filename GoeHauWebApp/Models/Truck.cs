using System;
using System.Collections.Generic;

namespace GoeHauWebApp.Models
{
    public partial class Truck
    {
        public Truck()
        {
            Orders = new HashSet<Order>();
        }

        public long Id { get; set; }
        public string? LicensePlate { get; set; }
        public long? DriverId { get; set; }

        public virtual User? Driver { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
