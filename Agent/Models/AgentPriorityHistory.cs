using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent.Models
{
    public class AgentPriorityHistory
    {
        public int Id { get; set; }
        public int AgentId { get; set; }
        public DateTime ChangeDate { get; set; }
        public int PriorityValue { get; set; }
        public Agent Agent { get; set; }
    }
}
