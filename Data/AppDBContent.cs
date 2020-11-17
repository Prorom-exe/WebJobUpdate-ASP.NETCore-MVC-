using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebJob.Data.Models;
using WebJob.Models;

namespace WebJob.Data
{
    public class AppDBContent: IdentityDbContext<User>
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options) { }

        public DbSet<Tovar> Tovar { get; set; }
        public DbSet<Category> Category { get; set; }

    }
}
