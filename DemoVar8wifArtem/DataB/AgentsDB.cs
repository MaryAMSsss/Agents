using DemoVar8wifArtem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoVar8wifArtem.DataB
{
    static class AgentsDB
    {
        public static List<Agent> GetAgents()
        {
            return BaseDB.DBContext.Agents.ToList();
        }

        public static void AddAgent(Agent agent)
        {
            BaseDB.DBContext.Agents.Add(agent);
            BaseDB.DBContext.SaveChanges();
        }

        public static void UpdateAgent(Agent editedAgent)
        {          
            BaseDB.DBContext.Agents.Update(editedAgent);
            BaseDB.DBContext.SaveChanges();
        }

        internal static void RemoveAgent(Agent selectedItem)
        {
            BaseDB.DBContext.Remove(selectedItem);
            BaseDB.DBContext.SaveChanges();
        }
    }
}
