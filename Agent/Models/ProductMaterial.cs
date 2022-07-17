using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent.Models
{
    public class ProductMaterial
    {
        public int ProductId { get; set; }
        public int MaterialId { get; set; }
        public int? Count { get; set; }
        public Product Product { get; set; }
        public Material Material { get; set; }
    }
}
