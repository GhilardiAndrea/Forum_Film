using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Web_App_Forum_Film.Areas.Identity;

namespace Web_App_Forum_Film.Data
{
    public class MyIdentityDbContext : IdentityDbContext<MyUser>
    {
        public MyIdentityDbContext(DbContextOptions<MyIdentityDbContext> options)
            : base(options)
        {
        }
    }
}
