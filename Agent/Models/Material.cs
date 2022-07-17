using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent.Models
{
    public class Material
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CountInPack { get; set; }
        public string Unit { get; set; }
        public int? CountInStock { get; set; }
        public int MinCount { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }
        public string Image { get; set; }
        public int MaterialTypeId { get; set; }
        public MaterialType MaterialType { get; set; }
        public ICollection<ProductMaterial> ProductMaterials { get; set; }
        public ICollection<MaterialCostHistory> MaterialCostHistories { get; set; }
        public ICollection<MaterialSupplier> MaterialSuppliers { get; set; }
    }
}
