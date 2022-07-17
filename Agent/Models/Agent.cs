using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent.Models
{
    public class Agent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AgentTypeId { get; set; }
        public string Address { get; set; }
        public string INN { get; set; }
        public string KPP { get; set; }
        public string DirectorName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Logo { get; set; }
        public int Priority { get; set; }
        public AgentType AgentType { get; set; }
        public ICollection<AgentPriorityHistory> AgentPriorityHistories { get; set; }
        public ICollection<ProductSale> ProductSales { get; set; }
        public ICollection<Shop> Shops { get; set; }
    }
}
