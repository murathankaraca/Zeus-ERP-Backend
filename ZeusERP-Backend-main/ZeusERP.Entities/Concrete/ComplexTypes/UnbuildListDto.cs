using System;
using System.Collections.Generic;
using System.Text;

using ZeusERP.Core.Entities;

namespace ZeusERP.Entities.Concrete.ComplexTypes
{
    public class UnbuildListDto : IDto
    {
        public int UnbuildOrderId { get; set; }
        public string UnbuildOrderReference { get; set; }
        public int ProductToManufactureId { get; set; }
        public string ProductToManufactureName { get; set; }
        public int ManufacturingOrderId { get; set; }
        public string ManufacturingOrderReference { get; set; }
        public int BoMId { get; set; }
        public string BoMReference { get; set; }
        public decimal Quantity { get; set; }
        public int SourceLocationId { get; set; }
        public string SourceLocationName { get; set; }
        public int DestinationLocationId { get; set; }
        public string DestinationLocationName { get; set; }
    }
}
