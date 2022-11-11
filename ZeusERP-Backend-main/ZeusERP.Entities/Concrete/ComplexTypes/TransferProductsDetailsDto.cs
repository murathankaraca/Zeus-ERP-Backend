using System;
using System.Collections.Generic;
using System.Text;

using ZeusERP.Core.Entities;

namespace ZeusERP.Entities.Concrete.ComplexTypes
{
    public class TransferProductsDetailsDto : IDto
    {
        public int TransferId { get; set; }
        public string TransferReference { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal DoneQuantity { get; set; }
    }
}
