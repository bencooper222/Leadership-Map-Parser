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

        private List<Leader> fullListLeaders;
        private List<Leader> rowHeaders; // the order of the leaders in the survey
        private IsConnection Evaluate;

        StreamWriter missing = File.CreateText("theMissing.txt"); // send this to a better place

        public ConnectionParser(string txtFileLocation, List<Leader> relevantPeople, IsConnection IsConnection)
            : base(txtFileLocation)
        {

            fullListLeaders = relevantPeople; // from mainDatabase
            rowHeaders = GetRowHeader(GetRow(2));
            this.Evaluate = IsConnection;
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


        public List<Connection> CreateConnections() // what does internal mean
        {
            // this needs to check if the friendship has already been created and if so, not add it again. Not sure how sigma.js reacts to multiple duplicate edges but I don't want to find out
            // make sure it does nothing if it gets a null
            List<Connection> connections = new List<Connection>();
            List<Leader> leadersWithSurvey = new List<Leader>();
            for (int i = 3; i < CountLines(); i++) // pretty sure it should be i=3 or something
            {
                string[] leaderData = GetArrayOfElements(GetRow(i));

                for (int ratingIndex = 5; ratingIndex < rowHeaders.Count; ratingIndex++)
                {
                    Leader leaderAtRowIndex = new Leader(leaderData[2], leaderData[3], int.Parse(leaderData[4]));
                    leadersWithSurvey.Add(leaderAtRowIndex);

                    Connection potentialConnection = new Connection(rowHeaders[ratingIndex - 5],
                        leaderAtRowIndex);


                    int location = connections.IndexOf(potentialConnection);

                    //if DNE, create. Else, add new rating.
                    if (location != -1) // if it exists
                    {
                        connections[location].AddRating(int.Parse(leaderData[ratingIndex]));
                    }
                    else
                    {

                        potentialConnection.AddRating(int.Parse(leaderData[ratingIndex]));
                        connections.Add(potentialConnection);
                    }

                }
            }

            return RemoveInvalidConnections(connections); // get rid of the bad connections
            //       throw new NotImplementedException();
        }

        /// <summary>
        /// Iterates through list of connections to get rid of invalid ones
        /// </summary>
        /// <param name="connections"></param>
        /// <returns></returns>
        private List<Connection> RemoveInvalidConnections(List<Connection> connections)
        {
            List<Connection>.Enumerator iterate = connections.GetEnumerator();

            connections.RemoveAll(c => c.connectees[0] == c.connectees[1]); // remove all connections with the same people
            connections.RemoveAll(c => !Evaluate(c)); // remove all connections deemed not high enough
            

            return connections;
        }
    }
}
