using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebJob.Models
{
    public class FakeRepository : IProductRepository
    {
        public IQueryable<Product> Products => new List<Product>
        {
            new Product{Name = "Подшипник", Price=300},
            new Product{Name = "Масло", Price=700},
            new Product{Name = "Фильтр", Price=250}

        }.AsQueryable<Product>();

    }
}
