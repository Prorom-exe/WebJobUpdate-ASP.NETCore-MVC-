using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using WebJob.Data.Models;
using WebJob.Models;

namespace WebJob.Data
{
    public class DBObjects
    {
       
        public static async Task Initial(AppDBContent content,UserManager<User> userManager, RoleManager<IdentityRole> roleManager) 
        {
            if (!roleManager.Roles.Any())
            {
               await roleManager.CreateAsync(new IdentityRole("Admin"));
               await roleManager.CreateAsync(new IdentityRole("Moderator"));
               await roleManager.CreateAsync(new IdentityRole("User"));
            }

            if (!userManager.Users.Any())
            {
                User user = new User { Email = "admin12@mail.ru", UserName = "BigAdmin", };
                string Password = "Admin90+";
                await userManager.CreateAsync(user,Password);
                await userManager.AddToRoleAsync(user, "Admin"); 
                await userManager.AddToRoleAsync(user, "Moderator");
            }

            if (!content.Category.Any())
            {
                content.Category.AddRange(Categories.Select(c => c.Value));
            }

            if (!content.Tovar.Any())
            {
                content.AddRange(
                    new Tovar
                    {
                        TovarName = "Вкладыши коренные",
                        Price = 4500,
                        Car = "Skoda octavia,Audi A4",
                        Quantity = 10,
                        CatalogId = 234893,
                        Img = "",
                        Category = Categories["Двигатель"]

                    },
                    new Tovar
                    {
                        TovarName = "Клемма",
                        Price = 250,
                        Car = "Ваз 2114",
                        Quantity = 10,
                        CatalogId = 2343,
                        Img = "",
                        Category = Categories["Электрика"]

                    },
                    new Tovar
                    {
                        TovarName = "Пружина",
                        Price = 700,
                        Car = "",
                        Quantity = 10,
                        CatalogId = 2343,
                        Img = "",
                        Category = Categories["Ходовая"]

                    }
                    );
            }

            content.SaveChanges();
        }
        private static Dictionary<string, Category> _category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (_category == null)
                {
                    var list = new Category[]
                    {
                        new Category{CategoryName = "Двигатель",ImgCat=" "},
                        new Category{CategoryName = "Ходовая",ImgCat=" "},
                        new Category{CategoryName = "Электрика",ImgCat=" "},
                        };
                    _category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                    {
                        _category.Add(el.CategoryName, el);
                        //_category.Add(el.ImgCat, el);
                        
                    }
                }
                return _category;
            }

            
        }
    }
}
 