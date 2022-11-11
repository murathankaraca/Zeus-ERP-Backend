using System;
using System.Collections.Generic;
using System.Text;

using ZeusERP.Core.Entities;
using ZeusERP.Entities.Concrete.Enums;

namespace ZeusERP.Entities.Concrete.ComplexTypes
{
    public class ReplenishmentDetailsDto : IDto
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public int ProductToReplenishId { get; set; }
        public string ProductToReplenishName { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public decimal OnHandQuantity { get; set; }
        public decimal OrderQuantity { get; set; }
        public ReplenishmentStatus Status { get; set; }
    }
}
