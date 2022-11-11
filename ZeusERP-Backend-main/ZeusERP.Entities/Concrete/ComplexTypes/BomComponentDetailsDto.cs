using System;
using System.Collections.Generic;
using System.Text;

using ZeusERP.Core.Entities;

namespace ZeusERP.Entities.Concrete.ComplexTypes
{
    public class BomComponentDetailsDto : IDto
    {
        public int BomComponentId { get; set; }
        public int BomId { get; set; }
        public string BomReference { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
    }
}
