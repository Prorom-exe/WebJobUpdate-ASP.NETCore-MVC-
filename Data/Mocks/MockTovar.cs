using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebJob.Interfaces;
using WebJob.Models;

namespace WebJob.Mocks
{
    public class MockTovar : ITovar
    {
        private readonly ICategory _category = new  MockCategory();
        public IEnumerable<Tovar> AllTovars { get
            {
                return new List<Tovar> { new Tovar {TovarName="Поршень",Price = 1500,Car="Skoda octavia,Audi A4", Quantity=10,CatalogId = 2343,Img= "", Category = _category.AllCategories.First()}
            };
            }
        }


        public Tovar currentTovar(int tovarId)
        {
            throw new NotImplementedException();
        }
    }
}
