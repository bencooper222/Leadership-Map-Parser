using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;



namespace LeadershipMap
{
    delegate bool IsConnection(Connection c);
    class Program
    {
        static void Main(string[] args)
        {

            LeaderParser lParse = new LeaderParser("C:/Users/Benjamn/Google Drive/Leadership Map/Data/Leaders.csv");



          

            Academy imsa = new Academy("IMSA", lParse.CreateLeaders());

            IsConnection evaluate = new IsConnection(ConnectionDeservesEdge);
            ConnectionParser cParse = new ConnectionParser("C:/Users/Benjamn/Google Drive/Leadership Map/Data/Connections.csv", imsa.Leaders,evaluate);

            StreamWriter writer = File.CreateText("connections.txt");
            writer.AutoFlush = true;
            foreach (Connection c in cParse.CreateConnections())
            {
                writer.WriteLine(c);
            }

            Console.WriteLine("YO");
            Console.Read();




            imsa.Connections = cParse.CreateConnections();

            imsa.CreateVerticesFile();
            imsa.CreateEdgesFile();


        }

        /// <summary>
        /// Determine if certain connection deserves an edge on the graph
        /// </summary>
        /// <param name="connect"></param>
        /// <returns></returns>
        private static bool ConnectionDeservesEdge(Connection connect)
        {
            int magicNumber = 2; // the number used to check the rating of the connection
            if (magicNumber < 1 || magicNumber > 4) throw new ArgumentOutOfRangeException();
            return true;
        }
    }
}

