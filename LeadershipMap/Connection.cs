using System.Collections.Generic;
using System;

namespace LeadershipMap
{
    public class Connection
    {
        public Leader[] connections { get; set; }
        private bool crowdSourced;
        private List<double> Ratings;

        public double connectionStrength
        {
            get
            {
                return Average(Ratings);
            }
        }

        public int totalRatings
        {
            get
            {
                return Ratings.Count;
            }
        }

        public string uniqueId
        {
            get
            {
                return connections[0] + "/" + connections[1] + ": " + connectionStrength;
            }
        }

        public Connection(Leader friend1, Leader friend2)
        {

            Ratings = new List<double>();

            connections = new Leader[2]; // make the friends data property
            connections[0] = friend1;
            connections[1] = friend2;

        }

        public void AddRating(double rating)
        {
            Ratings.Add(rating);
        }

        private double Average(List<double> doubles)
        {
            if (totalRatings == 0) throw new InvalidProgramException();

            double sum = 0;

            foreach (double d in doubles)
            {
                sum += d;
            }

            return sum / doubles.Count;
        }

        public override string ToString()
        {
            return uniqueId;
        }



    }
}