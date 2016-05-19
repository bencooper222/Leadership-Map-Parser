using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LeadershipMap
{
    class Program
    {
        static void Main(string[] args)
        {
            
            LeaderParser lParse = new LeaderParser("C:/Users/Benjamn/Google Drive/Leadership Map/Data/Leaders.csv");
/*
            Leader anon = lParse.CreateLeader(lParse.GetRow(0)); // just for testing

            LeaderWrapper lwrap = new LeaderWrapper(anon);

            Console.WriteLine(lwrap.ToJson());
            */
            
            List<Connection> TEST = new List<Connection>();

            Academy imsa = new Academy("IMSA", lParse.CreateLeaderObjects(), TEST);
            imsa.CreateVerticesFile();
            
            Console.Read(); 
        }
    }
}

