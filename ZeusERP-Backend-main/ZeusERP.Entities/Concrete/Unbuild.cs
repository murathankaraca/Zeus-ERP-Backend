using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using ZeusERP.Core.Entities;

namespace ZeusERP.Entities.Concrete
{
    [Table("t_manu_orders_unbuild")]
    public class Unbuild : IEntity
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public int ManufacturingOrderId { get; set; }
        public int BoMId { get; set; }
        public decimal Quantity { get; set; }
        public int SourceLocationId { get; set; }
        public int DestinationLocationId { get; set; }
    }
}
