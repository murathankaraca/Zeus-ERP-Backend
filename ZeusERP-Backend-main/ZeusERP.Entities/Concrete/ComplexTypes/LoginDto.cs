using System;
using System.Collections.Generic;
using System.Text;

using ZeusERP.Core.Entities;

namespace ZeusERP.Entities.Concrete.ComplexTypes
{
    public class LoginDto : IDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Remember { get; set; }
    }
}
