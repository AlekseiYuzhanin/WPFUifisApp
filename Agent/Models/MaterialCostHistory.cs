using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent.Models
{
    public class MaterialCostHistory
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public DateTime ChangeDate { get; set; }
        public decimal CostValue { get; set; }
        public Material Material { get; set; }
    }
}
