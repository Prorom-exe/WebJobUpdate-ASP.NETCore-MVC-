using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebJob.Models;

namespace WebJob.Data.Models
{
    public class BuyTovar
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int TovarId { get; set; }
        public string TovarName { get; set; }
        public string CatalogId { get; set; }
        public decimal Price { get; set; }
        public int BuyQantity { get; set; }
        public ShopCart Shop { get; set; }
        public string State { get; set; }
    }
}
