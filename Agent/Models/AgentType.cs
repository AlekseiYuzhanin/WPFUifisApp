using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent.Models
{
    public class AgentType
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public ICollection<Agent> Agents { get; set; }
    }
}
