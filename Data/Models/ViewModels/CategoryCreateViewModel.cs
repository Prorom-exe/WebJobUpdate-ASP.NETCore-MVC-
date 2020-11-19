using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebJob.Data.Models.ViewModels
{
    public class CategoryCreateViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public string Description { get; set; }
        public bool Visible { get; set; }

    }
}
