using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebJob.Models;

namespace WebJob.Interfaces
{
      public interface ITovar
    {
        IEnumerable<Tovar> AllTovars { get; }
        Tovar currentTovar(int tovarId);
    }
}
