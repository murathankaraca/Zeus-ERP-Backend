using System;
using System.Collections.Generic;
using System.Text;

using ZeusERP.Core.DataAccess;
using ZeusERP.Entities.Concrete;

namespace ZeusERP.DataAccess.Abstract
{
    public interface IOrderTransferProductsDao : IEntityRepository<TransferProducts>
    {
    }
}
