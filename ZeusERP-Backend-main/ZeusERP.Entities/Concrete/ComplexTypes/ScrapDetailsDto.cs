using System;
using System.Collections.Generic;
using System.Text;

using ZeusERP.Core.Entities;
using ZeusERP.Entities.Concrete.Enums;

namespace ZeusERP.Entities.Concrete.ComplexTypes
{
    public class ScrapDetailsDto : IDto
    {
        public int ScrapId { get; set; }
        public string OrderReference { get; set; }
        public string OrderDescription { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public DateTime ScheduledDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public int SourceLocationId { get; set; }
        public string SourceLocationName { get; set; }
        public int ScrapLocationId { get; set; }
        public string ScrapLocationName { get; set; }
        public ScrapStatus ScrapStatus { get; set; }
    }
}
