using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using ZeusERP.Core.Entities;
using ZeusERP.Entities.Concrete.Enums;

namespace ZeusERP.Entities.Concrete
{
    [Table("t_inv_orders_receipt")]
    public class Receipt : IEntity
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public int ReceiveFromId { get; set; }
        public DateTime ScheduledDate { get; set; }
        public int ReceiptOperationsId { get; set; }
    }
}