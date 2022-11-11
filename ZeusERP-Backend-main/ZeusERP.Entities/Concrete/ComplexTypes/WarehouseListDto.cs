using System;
using System.Collections.Generic;
using System.Text;

using ZeusERP.Core.Entities;

namespace ZeusERP.Entities.Concrete.ComplexTypes
{
    public class WarehouseListDto : IDto
    {
        public int WarehouseId { get; set; }
        public string WarehouseCode { get; set; }
        public string WarehouseName { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
    }
}
