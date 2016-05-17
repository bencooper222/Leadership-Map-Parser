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

        public List<Leader> leaders { get; set; }
        public List<Friendship> friendships { get; set; }
      

        string name { get; set; }

        public Academy(string name, List<Leader> leads, List<Friendship> bffls)
        {
            this.name = name;

            leaders = leads;
            friendships = bffls;

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
            foreach(Friendship fship in friendships) // make sure that all the friendships have actual leaders in them - just for robustness
            {
                foreach(Leader lead in fship.friends)
                {
                    if (!leaders.Contains(lead))
                    {
                        throw new InvalidProgramException();
                    }
                }
            }
        }

        public void CreateVerticesFile()
        {
            StreamWriter writer = File.CreateText("leaders.txt");

            foreach(Leader lead in leaders)
            {
                LeaderWrapper leadWrap = new LeaderWrapper(lead);
                writer.WriteLine(leadWrap.ToJson());
            }
        }

        public void CreateEdgesFile()
        {
            StreamWriter writer = File.CreateText("friendships.txt");

            foreach (Friendship friend in friendships)
            {
                writer.WriteLine(friend.ToJson());
            }
        }
    }
}
