using System.Collections.Generic;
using System;

namespace LeadershipMap
{
    public class Connection
    {
        public Leader[] connectees { get; set; }
        private bool crowdSourced
        {
            get
            {
                if (Ratings.Count > 1) return true;
                return false;
            }
        }
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
                return connectees[0] + "/" + connectees[1] + ": " + connectionStrength + "from " + totalRatings + " ratings";
            }
        }

        public Connection(Leader friend1, Leader friend2)
        {

            Ratings = new List<double>();

            connectees = new Leader[2]; // make the friends data property
            connectees[0] = friend1;
            connectees[1] = friend2;

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

        public static bool operator ==(Connection one, Connection two)
        {
            if ((one.connectees[0] == two.connectees[0] & one.connectees[1] == two.connectees[1])
                 || (one.connectees[0] == two.connectees[1] & one.connectees[1] == two.connectees[0]))
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(Connection one, Connection two)
        {
            if ((one.connectees[0] == two.connectees[0] & one.connectees[1] == two.connectees[1])
                 || (one.connectees[0] == two.connectees[1] & one.connectees[1] == two.connectees[0]))
            {
                return !true;
            }

            return !false;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Connection))
            {
                return false;
            }

            if (this == (Connection)obj)
            {
                return true;
            }

            return false;
        }
    }
}