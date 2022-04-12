using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api_Forum_Film.Services;
using Web_Api_Forum_Film.Services.Class;

namespace Web_Api_Forum_Film.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public DbSet<ForumPost> Posts { get; set; }

        public DbSet<Topic> Topics { get; set; }

        public DbSet<Messaggio_Class> Messaggi { get; set; }

        public DbSet<Film> Films { get; set; }

        public DbSet<MyUser> Users { get; set; }
    }
}
