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

namespace WebJob.Controllers
{
    [Authorize]
    public class ShopCartController:Controller
    {
        AppDBContent db;
        UserManager<User> _userManager;
        public ShopCartController(AppDBContent appDBContent, UserManager<User> userManager)
        {
            db = appDBContent;
            _userManager = userManager;
        }

        [HttpPost]

        public async Task<ActionResult> CartAdd(int Id, int Quantity)
        {
            User user = await _userManager.GetUserAsync(User);

            var cartTovar = await db.Tovar.FirstOrDefaultAsync(t => t.Id == Id);


            ShopCart shopCart = new ShopCart { User = user, TovarId = cartTovar.Id,TovarName=cartTovar.TovarName,Price=cartTovar.Price, BuyQantity = Quantity, CatalogId=cartTovar.CatalogId };
            db.ShopCart.Add(shopCart);
            await db.SaveChangesAsync();
            return View();
        }

        decimal sum = 0;
        public async Task<ViewResult> CartList()
        {
            var user = await _userManager.GetUserAsync(User);
            var carts = db.ShopCart.Where(u=>u.User==user);
            foreach(var c in carts)
            {
                sum += c.Price;
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
            var carts = db.ShopCart.Where(u => u.User == user);
            await db.BuyTovar.AddRangeAsync(carts);
            db.ShopCart.RemoveRange(carts);
            await db.SaveChangesAsync();
            return RedirectToAction("OrderList");
        }
        public IEnumerable<BuyTovar> buyTovars => db.BuyTovar;
        public ViewResult OrderList() => View(buyTovars); 
        
    }
}
