using System;
using System.Collections.Generic;
using System.Text;

using ZeusERP.Core.Entities;
using ZeusERP.Entities.Concrete.Enums;

namespace ZeusERP.Entities.Concrete.ComplexTypes
{
    public class ManufacturingDetailsDto : IDto
    {
        public int OrderId { get; set; }
        public string Reference { get; set; }
        public int ProductToManufactureId { get; set; }
        public string ProductToManufactureName { get; set; }
        public int BillOfMaterialsId { get; set; }
        public string BillOfMaterialsName { get; set; }
        public decimal QuantityToManufacture { get; set; }
        public decimal QuantityManufactured { get; set; }
        public DateTime ScheduledDate { get; set; }
        public int ResponsibleId { get; set; }
        public string ResponsibleName { get; set; }
        public int ComponentsId { get; set; }
        public IList<ManufacturingComponent> ComponentsUsed { get; set; }
        public int ComponentsLocationId { get; set; }
        public string ComponentsLocationName { get; set; }
        public int FinishedProductsLocationId { get; set; }
        public string FinishedProductsLocationName { get; set; }
        public ManufacturingState State { get; set; }
    }
}
