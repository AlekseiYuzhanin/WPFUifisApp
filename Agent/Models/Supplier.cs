using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string INN { get; set; }
        public DateTime StartDate { get; set; }
        public int QualityRating { get; set; }
        public string SupplierType { get; set; }
        public ICollection<MaterialSupplier> MaterialSuppliers { get; set; }

    }
}
