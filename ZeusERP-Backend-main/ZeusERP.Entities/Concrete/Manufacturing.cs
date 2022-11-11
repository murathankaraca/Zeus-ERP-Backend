using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using ZeusERP.Core.Entities;
using ZeusERP.Entities.Concrete.Enums;

namespace ZeusERP.Entities.Concrete
{
    [Table("t_manu_orders_manufacturing")]
    public class Manufacturing : IEntity
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public int ProductId { get; set; }
        public int BillOfMaterialsId { get; set; }
        public string BillOfMaterialsReference { get; set; }
        public decimal QuantityToManufacture { get; set; }
        public decimal QuantityManufactured { get; set; }
        public DateTime ScheduledDate { get; set; }
        public int ResponsibleId { get; set; }
        public int ComponentsId { get; set; }
        public int ComponentsLocationId { get; set; }
        public int FinishedProductsLocationId { get; set; }
        public ManufacturingState State { get; set; }
    }
}
