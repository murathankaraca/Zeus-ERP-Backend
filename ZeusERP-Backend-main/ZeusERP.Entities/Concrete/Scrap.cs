using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using ZeusERP.Core.Entities;
using ZeusERP.Entities.Concrete.Enums;

namespace ZeusERP.Entities.Concrete
{
    [Table("t_inv_orders_scrap")]
    public class Scrap : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }
        public int? ProductId { get; set; }
        public decimal Quantity { get; set; }
        public DateTime ScheduledDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public int? SourceLocationId { get; set; }
        public int? ScrapLocationId { get; set; }
        public ScrapStatus Status { get; set; }
    }
}
