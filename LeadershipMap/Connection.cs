using System.Collections.Generic;
using System;

namespace LeadershipMap
{
    public class Connection
    {
        public Leader[] connections { get; set; }
        private bool crowdSourced;
        private List<double> Ratings;
        public double connectionStrength { get; }

        public string uniqueId
        {
            get
            {
                return connections[0] + "/" + connections[1];
            }
        }

        public Connection(Leader friend1, Leader friend2, bool friend1RatingExist, bool friend2RatingExist, params double[] ratings)
        {
            crowdSourced = (friend1RatingExist && friend1RatingExist) ? true : false; //if both friends responded, then it counts as crowdsourced.

            connections = new Leader[2]; // make the friends data property
            connections[0] = friend1;
            connections[1] = friend2;



            foreach (double d in ratings)
            {
                Ratings.Add(d);
            }

            connectionStrength = Average(Ratings);

        }

        private double Average(List<double> doubles)
        {
            double sum = 0;

            foreach (double d in doubles)
            {
                sum += d;
            }

            return sum / doubles.Count;
        }

        public string ToJson()
        {
            throw new NotImplementedException();
        }

    }
}