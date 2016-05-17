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

            LeaderParser parse = new LeaderParser("C:/Users/Benjamn/Google Drive/Leadership Map/Data/Leaders.csv");

            Console.Write(parse.CreateLeader(parse.GetRow(0)));

            Console.Read();
        }
    }
}
