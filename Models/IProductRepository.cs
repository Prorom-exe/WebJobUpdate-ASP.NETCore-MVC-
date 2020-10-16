using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebJob.Models
{
    
    
        public interface IProductRepository { IQueryable<Product> Products { get; } }
    
}
