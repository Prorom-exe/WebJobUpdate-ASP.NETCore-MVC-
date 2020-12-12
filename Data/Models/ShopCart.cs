using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebJob.Models;

namespace WebJob.Data.Models
{
    public class ShopCart
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int TovarId { get; set; }
        public string CatalogId { get; set; }
        public string TovarName { get; set; }
        public decimal Price { get; set; }
        public int BuyQantity { get; set; }
        
    }
}
