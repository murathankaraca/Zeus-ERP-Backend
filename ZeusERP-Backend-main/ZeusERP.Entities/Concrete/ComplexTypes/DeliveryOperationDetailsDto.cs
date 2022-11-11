using System;
using System.Collections.Generic;
using System.Text;

using ZeusERP.Core.Entities;

namespace ZeusERP.Entities.Concrete.ComplexTypes
{
    public class DeliveryOperationDetailsDto : IDto
    {
        public int Id { get; set; }
        public int DeliveryOrderId { get; set; }
        public string Description { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public DateTime Deadline { get; set; }
        public decimal ReservedQuantity { get; set; }
        public decimal DoneQuantity { get; set; }
    }
}
