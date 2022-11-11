using System;
using System.Collections.Generic;
using System.Text;

using ZeusERP.Core.Entities;
using ZeusERP.Entities.Concrete.Enums;

namespace ZeusERP.Entities.Concrete.ComplexTypes
{
    public class ManufacturingListDto : IDto
    {
        public string OrderReference { get; set; }
        public DateTime OrderScheduledDate { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public bool AreAllComponentsAvailable { get; set; }
        public decimal QuantityToManufacture { get; set; }
        public ManufacturingState OrderState { get; set; }
    }
}
