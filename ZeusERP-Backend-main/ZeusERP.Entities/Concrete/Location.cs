using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using ZeusERP.Core.Entities;

namespace ZeusERP.Entities.Concrete
{
    [Table("t_inv_locations")]
    public class Location : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int LocationTypeId { get; set; }
        public int AddressId { get; set; }
        public int ParentLocationId { get; set; }
        public bool IsInternalLocation { get; set; }
        public bool IsScrapLocation { get; set; }
        public bool IsReturnLocation { get; set; }
        public string ExternalNote { get; set; }
        public int? StockId { get; set; }
    }
}
