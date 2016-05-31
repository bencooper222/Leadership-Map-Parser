using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LeadershipMap
{
    class ConnectionParser : Parser
    {

        private List<Leader> fullListLeaders; // the full database of leaders MIGHT be unecessary
        private Dictionary<Leader, int> LeadersWithData = new Dictionary<Leader, int>(); // list of leaders who actually filled out the survey with their row number
        private List<Leader> rowHeaders; // the order of the leaders in the survey

        StreamWriter missing = File.CreateText("theMissing.txt"); // send this to a better place

        public ConnectionParser(string txtFileLocation, List<Leader> relevantPeople) : base(txtFileLocation)
        {

            fullListLeaders = relevantPeople; // from mainDatabase

            for (int i = 3; i < this.CountLines(); i++) // add all the leaders and their rows locations to a dictionary
            {

                string row = GetRow(i);
                string id = GetArrayOfElements(row)[3];

                Leader evaluatee = fullListLeaders.Find(item => item.uniqueID == id);


                if (!LeadersWithData.Keys.Contains(evaluatee)) LeadersWithData.Add(fullListLeaders.Find(item => item.uniqueID == id), i);


            }

            rowHeaders = GetRowHeader(GetRow(2));
        }

        private List<Leader> GetRowHeader(string IDRow)
        {
            List<Leader> orderedLeaders = new List<Leader>();
            foreach (string s in GetArrayOfElements(IDRow))
            {
                if (s != "IGNORE") orderedLeaders.Add(fullListLeaders.Find(item => item.uniqueID == s));
            }

            return orderedLeaders;

        }

        /// <summary>
        /// Checks if the given Leader exists in the list that this parser's been given
        /// </summary>
        /// <param name="test"></param>
        /// <returns>True if exists, false if not</returns>
        private bool CheckLeaderExists(Leader test)
        {
            foreach (Leader lead in fullListLeaders)
            {
                if (lead == test) return true;
            }

            return false;
        }

        /// <summary>
        /// Given a specific leader, returns all the connections they have
        /// </summary>
        /// <param name="lead">This should be taken from the full list of leaders</param>
        /// <returns></returns>
        public List<Connection> CreateSpecificLeaderConnections(Leader lead)
        {
            if (!CheckLeaderExists(lead))
            {
                missing.WriteLine(lead);
                return null;
            }
            //I need to create a list of all the names in the surveydatabase

            Dictionary<Leader, List<Connection>> leaderConnections = new Dictionary<Leader, List<Connection>>();

            string[] specificLeaderData = GetArrayOfElements(GetRow(LeadersWithData[lead]));

        
            for (int i = 0; i < rowHeaders.Count; i++)
            {
                Connection connect = new Connection(lead, rowHeaders[i]);

                double rating;
                double.TryParse(specificLeaderData[i+4], out rating);
                connect.AddRating(rating);

                Console.WriteLine(i);



                if (leaderConnections.Keys.Contains(lead))
                {

                    leaderConnections[lead].Add(connect);
                }
                else
                {

                    leaderConnections.Add(lead, new List<Connection> { connect });
                }


                /*

                 if (leaderConnections.Keys.Contains(rowHeaders[LeadersWithData[lead]]))
                 {

                     leaderConnections[rowHeaders[LeadersWithData[lead]]].Add(connect);
                 }
                 else
                 {
                     if (leaderConnections.Keys.Contains(lead))
                     {

                         leaderConnections[lead].Add(connect);
                     }
                     else
                     {

                         leaderConnections.Add(lead, new List<Connection> { connect });
                     }


             }
                */
            }
            //not finished
            return DictionaryToList(leaderConnections);
        }

        /// <summary>
        /// Converts a dictionary to list by taking all of the values for each key and making a list
        /// </summary>
        /// <param name="dictionary">A Leader, List<Connection> dictionary</param>
        /// <returns>Full list of all connections in the dictionary</returns>
        private List<Connection> DictionaryToList(Dictionary<Leader, List<Connection>> dictionary)
        {
            List<Connection> connections = new List<Connection>();

            foreach (Leader lead in dictionary.Keys)
            {
                foreach (Connection c in dictionary[lead])
                {
                    connections.Add(c);
                }
            }

            return connections;
        }

        private Connection CreateSingleConnection()
        {
            throw new NotImplementedException();
        }



        public List<Connection> CreateFriendships() // what does internal mean
        {

            // this needs to check if the friendship has already been created and if so, not add it again. Not sure how sigma.js reacts to multiple duplicate edges but I don't want to find out
            //make sure it does nothing if it gets a null




            throw new NotImplementedException();
        }
    }
}
