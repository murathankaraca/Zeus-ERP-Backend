using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using ZeusERP.Core.Entities;
using ZeusERP.Entities.Concrete.Enums;

namespace ZeusERP.Entities.Concrete
{
    [Table("t_inv_orders")]
    public class Order : IEntity
    {
        public int Id { get; set; }
        public OperationType OperationType { get; set; }
        public string Code { get; set; }
        public int WarehouseId { get; set; }
        public int TypeOfOperationId { get; set; }
        public int DefaultSourceId { get; set; }
        public int DefaultDestinationId { get; set; }
    }
}