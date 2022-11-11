using System;
using System.Collections.Generic;
using System.Text;

using ZeusERP.Core.Entities;

namespace ZeusERP.Entities.Concrete.ComplexTypes
{
    public class LocationListDto : IDto
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string LocationCode { get; set; }
    }
}
