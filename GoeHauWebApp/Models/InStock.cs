using System;
using System.Collections.Generic;

namespace GoeHauWebApp.Models
{
    public partial class InStock
    {
        public long WarehouseId { get; set; }
        public long ProductId { get; set; }
        public long? UnitInStock { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual Warehouse Warehouse { get; set; } = null!;
    }
}
