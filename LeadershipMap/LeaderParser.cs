using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LeadershipMap
{
    class LeaderParser : Parser
    {


        private StreamReader reader;

        public LeaderParser(string txtFileLocation) : base(txtFileLocation) // pretty sure some dank inheritance stuff is going on here
        {
            reader = new StreamReader(txtFileLocation);
        }

        /// <summary>
        /// Only returns a leader object that DOES not have its organizations
        /// </summary>
        /// <param name="rowText"></param>
        /// <returns></returns>
        public Leader CreateLeader(string rowText)
        {
            int gradClass = 0;
            Int32.TryParse(GetElementFromRowText(2, rowText), out gradClass); // grab the graduating class

            Leader lead = new Leader(GetElementFromRowText(0, rowText), GetElementFromRowText(1, rowText), gradClass);

            return lead;
        }

        public List<Leader> CreateLeaderObjects()
        {

            List<Leader> leaders = new List<Leader>();
            for (int i = 0; i < this.CountLines(); i++)
            {
                leaders.Add(CreateLeader(reader.ReadLine()));
            }

            return leaders;
        }
    }
}
