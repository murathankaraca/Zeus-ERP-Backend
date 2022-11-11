using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using ZeusERP.Core.Entities;

namespace ZeusERP.Entities.Concrete
{
    [Table("t_inv_product_boms_comps")]
    public class BillOfMaterialsComponent : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int BomId { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
    }
}
