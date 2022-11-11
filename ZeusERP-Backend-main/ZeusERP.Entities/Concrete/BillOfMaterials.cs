using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using ZeusERP.Core.Entities;
using ZeusERP.Entities.Concrete.Enums;

namespace ZeusERP.Entities.Concrete
{
    [Table("t_inv_product_boms")]
    public class BillOfMaterials : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Reference { get; set; }
        public int ProductId { get; set; }
        public BomType BoMType { get; set; }
        public decimal Quantity { get; set; }
    }
}
