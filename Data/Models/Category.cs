using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebJob.Models
{
    
    
        public class Category 
        {
        public int Id { get; set; }
        

        public string CategoryName { get; set; }

        public string Description { get; set; }
        public bool Visible{ get; set; }
        public string ImgCat { get; set; }

        public List<Tovar> Tovars { get;  set; }

    }
    
}
