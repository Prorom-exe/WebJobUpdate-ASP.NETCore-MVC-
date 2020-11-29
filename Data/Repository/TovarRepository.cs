using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebJob.Interfaces;
using WebJob.Models;

namespace WebJob.Data.Repository
{
    public class TovarRepository : ITovar
    {
        private readonly AppDBContent appDBContent;
        public TovarRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IQueryable<Tovar> AllTovars => appDBContent.Tovar.Include(c=>c.Category);

        public Tovar currentTovar(int tovarId) => appDBContent.Tovar.FirstOrDefault(p => p.Id==tovarId);
       
    }
}
