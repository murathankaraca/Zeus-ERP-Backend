using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

using ZeusERP.Entities.Concrete;

namespace ZeusERP.DataAccess.Contexts
{
    public class IdentityContext : IdentityDbContext<SysUser, SysUserRole, string>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {

        }
    }
}
