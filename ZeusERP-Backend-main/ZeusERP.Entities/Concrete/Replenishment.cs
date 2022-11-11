using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using ZeusERP.Core.Entities;
using ZeusERP.Entities.Concrete.Enums;

namespace ZeusERP.Entities.Concrete
{
    [Table("t_inv_orders_replenishment")]
    public class Replenishment : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Reference { get; set; }
        public int ProductToReplenishId { get; set; }
        public int LocationId { get; set; }
        public decimal OnHandQuantity { get; set; }
        public decimal OrderQuantity { get; set; }
        public ReplenishmentStatus Status { get; set; }
    }
}
