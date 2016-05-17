using System.Collections.Generic;
using System;

namespace LeadershipMap
{
    public class Leader
    {
        public List<Organization> Organizations { get; set; }

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string fullName { get { return firstName + " " + lastName; } }
        public string uniqueID { get; set; }

        public int gradClass { get; set; } // make sure to throw ArgumentOutOfRangeException() if this isn't 6,7 or 8

        public Leader(string name, string uniqueID, int classNumber)
        {
            firstName = name.Substring(0, name.IndexOf(' '));
            lastName = name.Substring(name.IndexOf(' '));
            this.uniqueID = uniqueID;

            gradClass = classNumber; // throw that exception here pls
            //finish
        }

        public override string ToString()
        {
            return fullName + ": " + uniqueID;
        }

        public static bool operator ==(Leader one, Leader two)
        {
            throw new NotImplementedException();
        }

        public static bool operator !=(Leader one, Leader two)
        {
            throw new NotImplementedException();
        }

        public string ToJson()
        {
            throw new NotImplementedException();
        }
    }
}