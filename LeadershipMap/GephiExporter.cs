using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LeadershipMap
{
    class GephiExporter
    {

        List<Leader> Vertices;
        List<Connection> Edges;
        string fileLocation;

        public GephiExporter(List<Leader> vertices, List<Connection> edges, string fileLocation)
        {
            Vertices = vertices;
            Edges = edges;
            this.fileLocation = fileLocation;
        }


        private void WriteVertices()
        {
            StreamWriter verticesCSV = File.CreateText(fileLocation + "/Nodes.csv");
            verticesCSV.AutoFlush = true;

            verticesCSV.WriteLine("Id,Label");

            foreach (Leader v in Vertices)
            {
                string line = v.uniqueID + "," + v.fullName;
                verticesCSV.WriteLine(line);
            }
        }

        private void WriteEdges()
        {
            StreamWriter edgesCSV = File.CreateText(fileLocation + "/Edges.csv");
            edgesCSV.AutoFlush = true;

            edgesCSV.WriteLine("Source,Target,Weight,Type");

            foreach (Connection e in Edges)
            {
                string line = e.connectees[0].uniqueID + "," + e.connectees[1].uniqueID + "," +
                    e.connectionStrength + "," + "undirected";
                edgesCSV.WriteLine(line);
            }
            //https://gephi.org/users/supported-graph-formats/spreadsheet/
        }

        public void Export()
        {
            WriteEdges();
            WriteVertices();
        }



    }
}
