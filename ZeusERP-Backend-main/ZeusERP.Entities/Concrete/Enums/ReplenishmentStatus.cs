using System;
using System.Collections.Generic;
using System.Text;

namespace ZeusERP.Entities.Concrete.Enums
{
    public enum ReplenishmentStatus : int
    {
        Drafted = 0,
        InProgress = 1,
        Cancelled = 2,
        Insufficient = 3,
        Complete = 4
    }
}
