using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebJob.Data;
using WebJob.Data.Models.ViewModels;
using WebJob.Interfaces;
using WebJob.Models;

namespace WebJob.Controllers
{
    public class TovarController : Controller
    {
        private readonly ITovar _tovars;
        private readonly ICategory _categories;
        AppDBContent db;

        public TovarController (ITovar tovar, ICategory category,AppDBContent appDB)
        {
            _tovars = tovar;
            _categories = category;
            db = appDB;
        }
        
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
        //[Authorize(Roles="Admin,Moderator")]
        public ViewResult CategoryList() => View(_categories.AllCategories.ToList());
        public IActionResult CatCreate() => View();
        [HttpPost]
        public async Task<IActionResult> CatCreate(CategoryCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Category category1 = new Category { CategoryName = model.CategoryName, Description = model.Description, Visible = model.Visible };
                db.Category.Add(category1);
                await db.SaveChangesAsync();
                return RedirectToAction("CategoryList");
            }
            return View(model);
        }
        
        public async Task<IActionResult> CategoryEdit(int catId)
        {
            
            Category category =await db.Category.FindAsync(catId);
            CategoryCreateViewModel model = new CategoryCreateViewModel { Id = category.Id, CategoryName = category.CategoryName, Description = category.Description, Visible = category.Visible };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CategoryEdit(CategoryCreateViewModel model)
        {
            
            
            
                Category category = await db.Category.FindAsync(model.Id);
                if (category != null)
                {
                    category.CategoryName = model.CategoryName;
                    category.Description = model.Description;
                    category.Visible = model.Visible;
                    db.Category.Update(category);
                    await db.SaveChangesAsync();
                    return RedirectToAction("CategoryList");
                    
                }
            
            return View(model);
        }
    }



}
