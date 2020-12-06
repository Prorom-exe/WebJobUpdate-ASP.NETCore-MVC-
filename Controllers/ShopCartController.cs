using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebJob.Data;
using WebJob.Models;
using WebJob.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using WebJob.Interfaces;

namespace WebJob.Controllers
{
    [Authorize]
    public class ShopCartController:Controller
    {
        AppDBContent db;
        UserManager<User> _userManager;
        public IEnumerable<BuyTovar> buyTovars;
        public IEnumerable<Tovar> tovarQuantity;
        public ShopCartController(AppDBContent appDBContent, UserManager<User> userManager)
        {
            db = appDBContent;
            _userManager = userManager;
        }

        [HttpPost]

        public async Task<ActionResult> CartAdd(int Id, int Quantity, string page)
        {
            User user = await _userManager.GetUserAsync(User);

            var cartTovar = await db.Tovar.FirstOrDefaultAsync(t => t.Id == Id);

            
            ShopCart shopCart = new ShopCart { User = user, TovarId = cartTovar.Id,TovarName=cartTovar.TovarName,Price=cartTovar.Price, BuyQantity = Quantity, CatalogId=cartTovar.CatalogId };
            db.ShopCart.Add(shopCart);
            await db.SaveChangesAsync();
            return RedirectToAction("Category","Tovar",new {page });
           

        }

        decimal sum = 0;
        public async Task<ViewResult> CartList()
        {
            var user = await _userManager.GetUserAsync(User);
            var carts = db.ShopCart.Where(u=>u.User==user);
            foreach(var c in carts)
            {
                sum += c.Price*c.BuyQantity;
            }
            ViewBag.Sum = sum;
            return View(carts);
        }

        [HttpPost]
        public async Task<IActionResult> CartDelete(int Id)
        {
            var cartDelete = await db.ShopCart.FirstOrDefaultAsync(t=>t.Id==Id);
            User user = await _userManager.GetUserAsync(User);
            db.ShopCart.RemoveRange(cartDelete);
            await db.SaveChangesAsync();
             return RedirectToAction("CartList");
        }
        
        
        [HttpPost]
        public async Task<IActionResult> CartBuy()
        
        {
            User user = await _userManager.GetUserAsync(User);
            var carts = db.ShopCart.Where(u => u.User == user).ToList();
            
            Guid g = Guid.NewGuid();
             
            foreach (var b in carts)
            {
                if (tovarOstatok(b.TovarId, b.BuyQantity))
                {
                    BuyTovar buyTovar = new BuyTovar { User = user, OrderId = g, TovarName = b.TovarName,Price = b.Price*b.BuyQantity, State = "В обработке", TovarId = b.TovarId, BuyQantity = b.BuyQantity };
                   
                    await db.BuyTovar.AddRangeAsync(buyTovar);
                }
                else
                    return RedirectToAction("CartList");
            }
            foreach (var b in carts)
            {
                tovarQuantity = db.Tovar.Where(t => t.Id == b.TovarId);
                foreach (var p in tovarQuantity)
                {
                    p.Quantity -= b.BuyQantity;
                    
                }
                
                db.Tovar.UpdateRange(tovarQuantity);
            }

            db.ShopCart.RemoveRange(carts);
            await db.SaveChangesAsync();
            return RedirectToAction("OrderListUser");
        }
        
        public async Task<IActionResult> OrderListUser()

        {
            User user = await _userManager.GetUserAsync(User);
            buyTovars = db.BuyTovar.Where(u => u.User == user);
            var buyTovarsGroup = buyTovars.GroupBy(g => g.OrderId).ToList();
           
            return View(buyTovarsGroup);
        }

        public IActionResult OrderListAdmin()

        {
            
            var buyTovarsGroup =db.BuyTovar.GroupBy(g => g.User).ToList();

            return View(buyTovarsGroup);
        }
        protected bool tovarOstatok(int tovId,int quantity)
        {
            var quan = db.Tovar.Where(i => i.Id == tovId);
            foreach (var b in quan)
            {
                if (quantity <= b.Quantity)
                {
                    return true;
                }
                
            }
            return false;
        }

    }
}
