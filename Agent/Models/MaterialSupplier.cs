using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent.Models
{
    public class MaterialSupplier
    {
        public int MaterialId { get; set; }
        public int SupplierId { get; set; }
        public Material Material { get; set; }
        public Supplier Supplier { get; set; }
    }
}
