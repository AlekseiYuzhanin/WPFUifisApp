using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent.Models
{
    public class ProductType
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Product> Products { get; set;}
    }
}
