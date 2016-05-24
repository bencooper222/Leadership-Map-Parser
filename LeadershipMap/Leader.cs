using System.Collections.Generic;
using System;
using Newtonsoft.Json;

namespace LeadershipMap
{
    public class Leader
    {
        public List<string> Organizations { get; set; }

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string fullName { get { return firstName + " " + lastName; } }
        public string uniqueID { get; set; }

        public bool hasOrganizations
        {
            get
            {
                if (Organizations.Count > 0)
                {
                    return true;
                }
                else { return false; }
            }
        }

        public int gradClass { get; set; } // make sure to throw ArgumentOutOfRangeException() if this isn't 6,7 or 8

        public Leader(string name, string uniqueID, int classNumber)
        {
            firstName = name.Substring(0, name.IndexOf(' '));
            lastName = name.Substring(name.IndexOf(' ') + 1);
            this.uniqueID = uniqueID;

            gradClass = classNumber; // throw that exception here pls


            Organizations = new List<string>();
        }

        public override string ToString()
        {
            return fullName + ": " + uniqueID;
        }

        public static bool operator ==(Leader one, Leader two)
        {
            if (one.uniqueID == two.uniqueID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(Leader one, Leader two)
        {
            if (one.uniqueID == two.uniqueID)
            {
                return !true;
            }
            else
            {
                return !false;
            }
        }

        public override bool Equals(object obj)
        {
           if(!(obj is Leader)){
                return false;
            }

            if (this == (Leader)obj)
            {
                return true;
            }

            return false; 
        }


    }
}