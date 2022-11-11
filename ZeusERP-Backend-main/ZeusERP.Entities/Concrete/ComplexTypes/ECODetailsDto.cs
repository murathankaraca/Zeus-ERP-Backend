using System;
using System.Collections.Generic;
using System.Text;

using ZeusERP.Core.Entities;
using ZeusERP.Entities.Concrete.Enums;

namespace ZeusERP.Entities.Concrete.ComplexTypes
{
    public class ECODetailsDto : IDto
    {
        public int Id { get; set; }
        public string Summary { get; set; }
        public int ResponsibleId { get; set; }
        public string ResponsibleName { get; set; }
        // 0 : ProductOnly, 1: BoM
        public bool ApplyOn { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        // 0: ASAP, 1: At Date
        public bool Effectivity { get; set; }
        public DateTime EffectivityDate { get; set; }
        public int ECOTagsId { get; set; }
        public string Note { get; set; }
        public int ApproverId { get; set; }
        public string ApproverName { get; set; }
        public ECOStage EcoStage { get; set; }
    }
}
