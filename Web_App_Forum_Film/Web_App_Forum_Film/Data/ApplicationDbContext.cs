using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Web_App_Forum_Film.Areas.Identity;
using Web_Api_Forum_Film.Services.Class;

namespace Web_App_Forum_Film.Data
{
    public class MyIdentityDbContext : IdentityDbContext<MyUser>
    {
        public MyIdentityDbContext(DbContextOptions<MyIdentityDbContext> options)
            : base(options)
        {
        }
        public DbSet<Web_Api_Forum_Film.Services.Class.Topic> Topic { get; set; }
    }
}
