using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using ZeusERP.Core.Entities;

namespace ZeusERP.Entities.Concrete
{
    [Table("t_inv_routes")]
    public class Route : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int FromLocationId { get; set; }
        public int ToLocationId { get; set; }
        public int OperationTypeId { get; set; }
        public bool RequiresValidation { get; set; }
        public int RulesId { get; set; }
    }
}
