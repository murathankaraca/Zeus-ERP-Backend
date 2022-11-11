using System;
using System.Collections.Generic;
using System.Text;

using ZeusERP.Core.Entities;

namespace ZeusERP.Entities.Concrete.ComplexTypes
{
    public class LocationDetailsDto : IDto
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string LocationCode { get; set; }
        public int LocationTypeId { get; set; }
        public string LocationTypeName { get; set; }
        public int AddressId { get; set; }
        public string AddressTitle { get; set; }
        public int ParentLocationId { get; set; }
        public string ParentLocationName { get; set; }
        public bool IsInternalLocation { get; set; }
        public bool IsScrapLocation { get; set; }
        public bool IsReturnLocation { get; set; }
        public string ExternalNote { get; set; }
        public int? StockId { get; set; }

    }
}
