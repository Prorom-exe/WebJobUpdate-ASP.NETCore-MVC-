using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebJob.Models;

namespace WebJob.Interfaces
{
     public interface ICategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
