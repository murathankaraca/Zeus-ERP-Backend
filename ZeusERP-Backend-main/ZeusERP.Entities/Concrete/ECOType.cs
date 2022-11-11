using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using ZeusERP.Core.Entities;

namespace ZeusERP.Entities.Concrete
{
    [Table("t_plm_eco_types")]
    public class ECOType : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAlias { get; set; }
    }
}
