using System;
using System.Collections.Generic;
using System.Text;

using ZeusERP.Core.Entities;

namespace ZeusERP.Entities.Concrete
{
    public class TransferProducts : IEntity
    {
        public int TransferId { get; set; }
        public int ProductId { get; set; }
        public decimal DoneQuantity { get; set; }
    }
}
