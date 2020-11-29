using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebJob.Models;

namespace WebJob.Interfaces
{
      public interface ITovar
    {
        IQueryable<Tovar> AllTovars { get; }
        Tovar currentTovar(int tovarId);
    }
}
