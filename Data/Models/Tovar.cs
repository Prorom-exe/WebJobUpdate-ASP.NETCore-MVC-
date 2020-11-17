using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebJob.Models
{
    public class Tovar
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }

        public decimal Price { get; set; }
        public string TovarName { get; set; }

        public int CatalogId { get; set; }

        public string Car { get; set; }

        public string Img { get; set; }
        public uint Quantity { get; set; }
        public virtual Category Category { get; set; }


    }
}
