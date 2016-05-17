using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LeadershipMap
{
    class FriendshipWrapper : JsonWrapper
    {
        string id;
        string source;
        string target;

        public FriendshipWrapper(Friendship ship)
        {
            id = ship.uniqueId;
            source = ship.friends[0].uniqueID;
            target = ship.friends[1].uniqueID;
        }

    }
}
