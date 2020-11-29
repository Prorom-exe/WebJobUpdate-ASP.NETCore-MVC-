using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebJob.Data.Configurations;
using WebJob.Data.Models;
using WebJob.Models;

namespace WebJob.Data
{
    public class AppDBContent: IdentityDbContext<User>
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options) { }

        public DbSet<Tovar> Tovar { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ShopCart> ShopCart { get; set; }
        public DbSet<BuyTovar> BuyTovar { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new CategoryConfiguration());
           
        }

    }
}
