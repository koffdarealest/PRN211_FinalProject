using System;
using System.Collections.Generic;

namespace GoeHauWebApp.Models
{
    public partial class Order
    {
        public long Id { get; set; }
        public long? ProductId { get; set; }
        public long? WarehouseId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public string? Destination { get; set; }
        public long? TruckId { get; set; }
        public int? Quantity { get; set; }
        public decimal? TotalPrice { get; set; }
        public long? CreateBy { get; set; }

        public virtual User? CreateByNavigation { get; set; }
        public virtual Product? Product { get; set; }
        public virtual Truck? Truck { get; set; }
        public virtual Warehouse? Warehouse { get; set; }
    }
}
