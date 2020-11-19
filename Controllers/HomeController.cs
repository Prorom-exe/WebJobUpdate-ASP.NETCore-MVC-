using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebJob.Interfaces;
using WebJob.Models;

namespace WebJob.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITovar _tovars;
        private readonly ICategory _categories;

        public HomeController(ITovar tovar, ICategory category)
        {
            _tovars = tovar;
            _categories = category;
        }
        public ViewResult List()
        {
            //var category = _categories;

            return View(_categories.AllCategories);
                
        }

        public ViewResult Administrator()
        {
            return View();
        }

    }
}
