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
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string TovarName { get; set; }
        public int TovarId { get; set; }
        public Guid OrderId { get; set; }
        public int BuyQantity { get; set; }
        public decimal Price { get; set; }
        public string State { get; set; }
    }
}
