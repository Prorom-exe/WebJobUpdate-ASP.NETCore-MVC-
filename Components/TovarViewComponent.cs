using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebJob.Interfaces;

namespace WebJob.Components
{
    public class TovarViewComponent:ViewComponent
    {
        private readonly ICategory category1;
        public TovarViewComponent(ICategory category)

        {
            category1 = category;
            
        }
        


        public IViewComponentResult Invoke(int selectedCategory)
        {
            ViewBag.Category = selectedCategory;
            return View(category1.AllCategories);
        }
    }
}
