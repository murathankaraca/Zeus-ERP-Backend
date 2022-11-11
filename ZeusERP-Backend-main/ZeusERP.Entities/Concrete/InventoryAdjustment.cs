using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using ZeusERP.Core.Entities;

namespace ZeusERP.Entities.Concrete
{
    [Table("t_inv_adjustments")]
    public class InventoryAdjustment : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Reference { get; set; }
        public int LocationsId { get; set; }
        public int ProductsId { get; set; }
        public int InventoryLinesId { get; set; }
    }
}
