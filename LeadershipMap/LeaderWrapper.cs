using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LeadershipMap
{
    class LeaderWrapper
    {
        string id;
        string label; // fullname

        int x;
        int y;

        static int size = 1;
        public LeaderWrapper(Leader leader, int x = 0, int y = 0)
        {
            id = leader.uniqueID;
            label = leader.fullName;

            this.x = x;
            this.y = y;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
