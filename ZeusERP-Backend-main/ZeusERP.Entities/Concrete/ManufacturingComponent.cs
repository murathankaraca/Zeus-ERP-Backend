using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using ZeusERP.Core.Entities;

namespace ZeusERP.Entities.Concrete
{
    [Table("t_manu_orders_manufacturing_comps")]
    public class ManufacturingComponent : IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal QuantityToConsume { get; set; }
        public decimal QuantityConsumed { get; set; }
        public bool IsAvailable { get; set; }

    }
}
