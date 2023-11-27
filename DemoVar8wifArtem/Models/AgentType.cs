using System;
using System.Collections.Generic;

namespace DemoVar8wifArtem.Models
{
    public partial class AgentType
    {
        public AgentType()
        {
            Agents = new HashSet<Agent>();
        }

        public int Id { get; set; }
        public string? Description { get; set; }


        public virtual ICollection<Agent> Agents { get; set; }
    }
}
