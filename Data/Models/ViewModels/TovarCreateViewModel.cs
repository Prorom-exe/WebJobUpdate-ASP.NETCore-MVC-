using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebJob.Models;

namespace WebJob.Data.Models.ViewModels
{
    public class TovarCreateViewModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }

        public decimal Price { get; set; }
        public string TovarName { get; set; }

        public string CatalogId { get; set; }

        public string Car { get; set; }

        public bool Visible { get; set; }
        public IFormFile Path { get; set; }
        public uint Quantity { get; set; }
        public virtual Category Category { get; set; }
    }
}
