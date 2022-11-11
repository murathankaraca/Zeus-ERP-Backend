using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using ZeusERP.Core.Entities;

namespace ZeusERP.Entities.Concrete
{
    [Table("t_inv_orders_delivery_ops")]
    public class DeliveryOperation : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int DeliveryOrderId { get; set; }
        public string Description { get; set; }
        public int? ProductId { get; set; }
        public DateTime Deadline { get; set; }
        public decimal ReservedQuantity { get; set; }
        public decimal DoneQuantity { get; set; }
    }
}
