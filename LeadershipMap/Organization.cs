using System.Collections.Generic;
using System;
using Newtonsoft.Json;


namespace LeadershipMap
{
    public class Organization
    {
        public List<Leader> Leaders { get; set; }

        public static bool operator ==(Organization one, Organization two)
        {
            throw new NotImplementedException();
        }

        public static bool operator !=(Organization one, Organization two)
        {
            throw new NotImplementedException();
        }

      
    }
}