using System;
using System.Collections.Generic;
using System.Text;

using ZeusERP.Core.Entities;

namespace ZeusERP.Entities.Concrete.ComplexTypes
{
    public class ProductListDto : IDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductQuantity { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public decimal ProductCost { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
