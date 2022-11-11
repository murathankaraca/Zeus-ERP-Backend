using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using ZeusERP.Core.Entities;

namespace ZeusERP.Entities.Concrete
{
    [Table("t_inv_warehouses")]
    public class Warehouse : IEntity
    {
        public int Id { get; set; }
        public string WarehouseCode { get; set; }
        public string Name { get; set; }
        public bool HasLimitedStockCount { get; set; }
        public decimal StockLimit { get; set; }
        public bool UsedForManufacture { get; set; }
        public int RouteListId { get; set; }
        public int LocationId { get; set; }
    }
}
