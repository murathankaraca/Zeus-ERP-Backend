using System;
using System.Collections.Generic;
using System.Text;

using ZeusERP.Core.Entities;

namespace ZeusERP.Entities.Concrete.ComplexTypes
{
    public class TransferListDto : IDto
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public int ReceiveFromId { get; set; }
        public string ReceiveFromName { get; set; }
        public int DestinationLocationId { get; set; }
        public string DestinationLocationName { get; set; }
        public DateTime ScheduledDate { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public int ResponsibleId { get; set; }
        public string ResponsibleName { get; set; }
    }
}
