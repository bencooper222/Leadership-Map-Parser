using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadershipMap
{
    class Program
    {
        static void Main(string[] args)
        {

            LeaderParser lParse = new LeaderParser("C:/Users/Benjamn/Google Drive/Leadership Map/Data/Leaders.csv");

            Leader anon = lParse.CreateLeader(lParse.GetRow(0)); // privacy protections OP

            
            /*
            List<Friendship> TEST = new List<Friendship>();

            Academy imsa = new Academy("imsa", lParse.CreateLeaderObjects(), TEST);
            */
            Console.Read(); 
        }
    }
}
