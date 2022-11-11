using System;
using System.Collections.Generic;
using System.Text;

using ZeusERP.Core.Entities;

namespace ZeusERP.Entities.Concrete.ComplexTypes
{
    public class WarehouseDetailsDto : IDto
    {
        public int WarehouseId { get; set; }
        public string WarehouseCode { get; set; }
        public string WarehouseName { get; set; }
        public bool HasLimitedStockCount { get; set; }
        public decimal StockLimit { get; set; }
        public bool UsedForManufacture { get; set; }
        public int RouteListId { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string PhotoPath { get; set; }
    }
}
