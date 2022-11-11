using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using ZeusERP.Core.Entities;

namespace ZeusERP.Entities.Concrete
{
    [Table("t_inv_optypes")]
    public class OperationType : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string OperationCode { get; set; }
        public int WarehouseId { get; set; }
    }
}
