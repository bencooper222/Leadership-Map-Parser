using System.Collections.Generic;
using System;

namespace LeadershipMap
{
    public class Friendship
    {
        public Leader[] friends { get; set; }
        private bool crowdSourced;
        private List<double> Ratings;
        public double friendshipStrength { get; }
        

        public Friendship(Leader friend1, Leader friend2, bool friend1RatingExist, bool friend2RatingExist, params double[] ratings)
        {
            crowdSourced = (friend1RatingExist && friend1RatingExist) ? true : false; //if both friends responded, then it counts as crowdsourced.

            friends = new Leader[2]; // make the friends data property
            friends[0] = friend1;
            friends[1] = friend2;
            
            foreach(double d in ratings)
            {
                Ratings.Add(d);
            }

            friendshipStrength = Average(Ratings);
            
         }

        private double Average(List<double> doubles)
        {
            double sum = 0;

            foreach(double d in doubles)
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