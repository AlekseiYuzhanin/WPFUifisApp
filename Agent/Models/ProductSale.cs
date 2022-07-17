using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent.Models
{
    public class ProductSale
    {
        public int Id { get; set; }
        public int AgentId { get; set; }
        public int ProductId { get; set; }
        public DateTime SaleDate { get; set; }
        public int ProductCount { get; set; }
        public Agent Agent { get; set; }
    }
}
