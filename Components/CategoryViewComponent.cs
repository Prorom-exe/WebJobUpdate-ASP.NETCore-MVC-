using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebJob.Interfaces;
using WebJob.Models;

namespace WebJob.Views.Components
{
    public class CategoryViewComponent:ViewComponent
    {
        //private readonly ICategory _category;

        List<string> catName = new List<string>();
        public CategoryViewComponent(ICategory category)

        {
            //_category = category;
            foreach(var cat in category.AllCategories)
            {
                catName.Add(Convert.ToString(cat.CategoryName));
                
            }
            
        }


        
         public IViewComponentResult Invoke() 
        {
            return View(catName);
        }   
            
                    
    }
}
