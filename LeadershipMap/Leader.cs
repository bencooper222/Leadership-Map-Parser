using System.Collections.Generic;
using System;

namespace LeadershipMap
{
    public class Leader
    {
        public List<Organization> Organizations { get; set; }


        public static bool operator ==(Leader one, Leader two)
        {
            throw new NotImplementedException();
        }

        public static bool operator !=(Leader one, Leader two)
        {
            throw new NotImplementedException();
        }

        public string ToJson()
        {
            throw new NotImplementedException();
        }
    }
}