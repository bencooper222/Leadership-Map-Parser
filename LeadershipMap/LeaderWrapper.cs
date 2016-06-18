using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LeadershipMap
{
    public class LeaderWrapper : JsonWrapper
    {
        public string id; // unique ID
        public string label; // fullname

        public int x;
        public int y;

        public static int size = 1; // maybe remove static

        public LeaderWrapper(Leader leader, int x = 0, int y = 0)
        {
            id = leader.uniqueID;
            label = leader.fullName;

            this.x = x;
            this.y = y;
        }

      
    }
}
