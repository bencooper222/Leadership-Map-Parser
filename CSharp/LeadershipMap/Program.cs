﻿using System;
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
            
            LeaderParser lParse = new LeaderParser("C:/Users/Benjamn/Google Drive/Leadership Map/Data/RAW/Leaders.csv");



          

            Academy imsa = new Academy("IMSA", lParse.CreateLeaders());

            IsConnection evaluate = new IsConnection(ConnectionDeservesEdge);
            
            ConnectionParser cParse = new ConnectionParser("C:/Users/Benjamn/Google Drive/Leadership Map/Data/RAW/Connections.csv", imsa.Leaders,evaluate);

         



            imsa.Connections = cParse.CreateConnections();

            StreamWriter writer = File.CreateText("connectionregression.txt");

            foreach(Connection c in imsa.Connections)
            {
                string line = c.ToString();
                foreach(double rating in c.Ratings)
                {
                    line += "," + rating;
                }
                writer.WriteLine(line); 
            }

            //imsa.CreateVerticesFile();
            //imsa.CreateEdgesFile();

            //Console.WriteLine(evaluate(imsa.Connections[0]));
            // to use with Gephi organization tools
            GephiExporter export = new GephiExporter(imsa.Leaders, imsa.Connections, "C:/Users/Benjamn/Google Drive/Leadership Map/Data/Gephi");
            export.Export();

            Console.WriteLine("Complete");
            Console.Read();



        }


        /// <summary>
        /// Determine if certain connection deserves an edge on the graph
        /// </summary>
        /// <param name="connect"></param>
        /// <returns>boolean if given connection is strong enough</returns>
        private static bool ConnectionDeservesEdge(Connection connect)
        {
           

            if (connect.connectionStrength ==0) return false; //only don't show negligble connections

            return true;
        }
    }
}

