using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using ZeusERP.Core.Entities;

namespace ZeusERP.Entities.Concrete
{
    [Table("t_inv_orders_transfer")]
    public class Transfer : IEntity
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public int ReceiveFromId { get; set; }
        public int OperationTypeId { get; set; }
        public int DestinationLocationId { get; set; }
        public DateTime ScheduledDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public int TransferProductsId { get; set; }
        public int ResponsibleId { get; set; }
    }
}
