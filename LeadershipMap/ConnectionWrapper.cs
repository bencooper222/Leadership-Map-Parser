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
            source = ship.connections[0].uniqueID;
            target = ship.connections[1].uniqueID;
        }

    }
}
