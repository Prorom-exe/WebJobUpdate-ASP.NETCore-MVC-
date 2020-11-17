using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebJob.Data;
using WebJob.Interfaces;
using WebJob.Models;

namespace WebJob.Controllers
{
    public class TovarController : Controller
    {
        private readonly ITovar _tovars;
        private readonly ICategory _categories;

        public TovarController (ITovar tovar, ICategory category)
        {
            _tovars = tovar;
            _categories = category;
        }
        [Route("Tovar/Category")]
        [Route("Tovar/Category/{category?}")]

        public ViewResult Category(string category)
        {
            string _cat = category;
            IEnumerable<Tovar> tovars = null;
            
            string currCatName = null;

            
            if (string.IsNullOrEmpty(category))
            {
                tovars = _tovars.AllTovars.OrderBy(i => i.Id);
            }
            else
            {
                foreach (var p in _categories.AllCategories)
                {
                    if (string.Equals(p.CategoryName, category))
                    {
                         currCatName = p.CategoryName;
                        break;
                    }
                }

                if (string.Equals(currCatName, category, StringComparison.OrdinalIgnoreCase))
                {
                    tovars = _tovars.AllTovars.Where(i => i.Category.CategoryName.Equals(currCatName));
                }
              
            }
            return View(tovars);
        }





    }



}
