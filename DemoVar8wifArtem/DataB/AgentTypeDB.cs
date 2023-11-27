using DemoVar8wifArtem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoVar8wifArtem.DataB
{
    static class AgentTypeDB
    {
        public static List<AgentType> GetAgentType()
        {
            return BaseDB.DBContext.AgentTypes.ToList();
        }
    }
}
