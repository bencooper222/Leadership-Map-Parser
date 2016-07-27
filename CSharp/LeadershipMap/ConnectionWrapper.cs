using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LeadershipMap
{
    class ConnectionWrapper : JsonWrapper
    {
        public string id;
        public string source;
        public string target;

        public ConnectionWrapper(Connection ship)
        {
            id = ship.uniqueId;
            source = ship.connectees[0].uniqueID;
            target = ship.connectees[1].uniqueID;
        }

    }
}
