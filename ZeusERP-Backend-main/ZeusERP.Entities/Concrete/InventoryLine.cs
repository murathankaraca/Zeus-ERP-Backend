using System;
using System.Collections.Generic;
using System.Text;

using ZeusERP.Core.Entities;

namespace ZeusERP.Entities.Concrete
{
    public class InventoryLine : IEntity
    {
        public int ProductId { get; set; }
        public int LocationId { get; set; }
        public decimal OnHandQuantity { get; set; }
        public decimal CountedQuantity { get; set; }
    }
}
