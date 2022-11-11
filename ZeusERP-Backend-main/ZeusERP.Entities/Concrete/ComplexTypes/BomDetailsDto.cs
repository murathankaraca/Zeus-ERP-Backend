using System;
using System.Collections.Generic;
using System.Text;

using ZeusERP.Core.Entities;
using ZeusERP.Entities.Concrete.Enums;

namespace ZeusERP.Entities.Concrete.ComplexTypes
{
    public class BomDetailsDto : IDto
    {
        public int BomId { get; set; }
        public string BomReference { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public BomType BomType { get; set; }
        public decimal Quantity { get; set; }
        public IList<BillOfMaterialsComponent> BomComponents { get; set; }
    }
}
