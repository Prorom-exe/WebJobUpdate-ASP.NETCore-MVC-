using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebJob.Interfaces;
using WebJob.Models;

namespace WebJob.Mocks
{
    public class MockCategory : ICategory
    {
        public IEnumerable<Category> AllCategories {

            get
            {
                return new List<Category>
            {
                new Category{CategoryName = "Двигатель"},
                new Category{CategoryName = "Ходовая"},
            };

            } }
    }
}
