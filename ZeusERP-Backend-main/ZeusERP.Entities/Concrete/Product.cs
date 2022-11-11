using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using ZeusERP.Core.Entities;
using ZeusERP.Entities.Concrete.Enums;

namespace ZeusERP.Entities.Concrete
{
    [Table("t_inv_products")]
    public class Product : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        [Required, MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        [Required]
        public ProductType Type { get; set; }
        public string BarcodeNumber { get; set; }
        public decimal UnitCount { get; set; }
        public decimal UnitCost { get; set; }
        public decimal UnitPrice { get; set; }
        public int? BillOfMaterialsId { get; set; }
        public bool CanBePurchased { get; set; }
        public bool CanBeSold { get; set; }
        public int? ResponsibleId { get; set; }
        public decimal Weight { get; set; }
        public decimal Volume { get; set; }
        public int? BoMId { get; set; }
        public string? ImgPath { get; set; }
    }
}
