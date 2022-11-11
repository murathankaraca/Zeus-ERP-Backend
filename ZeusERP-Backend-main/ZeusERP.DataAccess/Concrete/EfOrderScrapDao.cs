using System;
using System.Collections.Generic;
using System.Text;

using ZeusERP.Core.DataAccess.EntityFramework;
using ZeusERP.DataAccess.Abstract;
using ZeusERP.DataAccess.Contexts;
using ZeusERP.Entities.Concrete;

namespace ZeusERP.DataAccess.Concrete
{
    public class EfOrderScrapDao : EfEntityRepositoryBase<Scrap, ZeusContext>, IOrderScrapDao
    {
    }
}
