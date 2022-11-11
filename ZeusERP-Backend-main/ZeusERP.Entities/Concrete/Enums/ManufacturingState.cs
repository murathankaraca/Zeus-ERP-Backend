using System;
using System.Collections.Generic;
using System.Text;

namespace ZeusERP.Entities.Concrete.Enums
{
    public enum ManufacturingState : int
    {
        Drafted = 0,
        InProgress = 1,
        Confirmed = 2,
        Cancelled = 3,
        Done = 4,
    }
}
