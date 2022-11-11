using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using ZeusERP.Core.Entities;
using ZeusERP.Entities.Concrete.Enums;

namespace ZeusERP.Entities.Concrete
{
    [Table("t_plm_ecos")]
    public class EngineeringChangeOrder : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Summary { get; set; }
        public int ResponsibleId { get; set; }
        // 0 : ProductOnly, 1: BoM
        public bool ApplyOn { get; set; }
        public int ProductId { get; set; }
        // 0: ASAP, 1: At Date
        public bool Effectivity { get; set; }
        public DateTime EffectivityDate { get; set; }
        public int ECOTagsId { get; set; }
        public string Note { get; set; }
        public int ApproverId { get; set; }
        public ECOStage EcoStage { get; set; }

    }
}
