using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace LeadershipMap
{
    class Program
    {
        static void Main(string[] args)
        {

            LeaderParser lParse = new LeaderParser("C:/Users/Benjamn/Google Drive/Leadership Map/Data/Leaders.csv");




          




            Academy imsa = new Academy("IMSA", lParse.CreateLeaderObjects());

            ConnectionParser cParse = new ConnectionParser("C:/Users/Benjamn/Google Drive/Leadership Map/Data/Connections.csv", imsa.Leaders);

            StreamWriter writer = File.CreateText("Erich.txt");
            foreach (Connection c in cParse.CreateSpecificLeaderConnections(imsa.Leaders.Find(item => item.uniqueID == "blueAnglerFish760"))){
                writer.WriteLine(c);
            }
            Console.WriteLine("done");
            Console.Read();


            imsa.Connections = cParse.CreateFriendships();

            imsa.CreateVerticesFile();
            imsa.CreateEdgesFile();


        }
    }
}

