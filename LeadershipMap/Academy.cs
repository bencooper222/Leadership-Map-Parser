using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LeadershipMap
{
    class Academy
    {

        public List<Leader> Leaders { get; set; }
        public List<Connection> Connections { get; set; }
      

        string Name { get; set; }

        public Academy(string name, List<Leader> leads)
        {
            Name = name;

            Leaders = leads;
        

            // might bring back that stuff but with strings
/*
            foreach(Leader lead in leads) // add each leader's organizations if it is not already in the list
            {
                foreach(Organization org in lead.Organizations)
                {
                    if (!organizations.Contains(org))
                    {
                        organizations.Add(org);
                    }
                }
            }
            */
           
        }

        public void CreateVerticesFile()
        {
            StreamWriter writer = File.CreateText("leaders.txt");

            foreach(Leader lead in Leaders)
            {
                LeaderWrapper leadWrap = new LeaderWrapper(lead);
                writer.WriteLine(leadWrap.ToJson());
            }
        }

        public void CreateEdgesFile()
        {
            

            StreamWriter writer = File.CreateText("connections_at_threshold.txt");

            writer.WriteLine("\"nodes\"" + ": [");
            foreach (Connection connectee in Connections)
            {
                ConnectionWrapper connectWrap = new ConnectionWrapper(connectee);
                writer.WriteLine(connectWrap.ToJson());
            }
            writer.WriteLine("]");
        }
    }
}
