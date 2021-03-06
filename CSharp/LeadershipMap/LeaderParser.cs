﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LeadershipMap
{
    class LeaderParser : SpreadsheetParser
    {


   

        public LeaderParser(string txtFileLocation) : base(txtFileLocation) // pretty sure some dank inheritance stuff is going on here
        {
           
        }

        /// <summary>
        /// Only returns a leader object that DOES not have its organizations
        /// </summary>
        /// <param name="rowText"></param>
        /// <returns></returns>
        public Leader CreateLeader(string rowText)
        {
            int gradClass = 0;
            Int32.TryParse(GetElementFromRowText(2, rowText), out gradClass); // grab the graduating class

            Leader lead = new Leader(GetElementFromRowText(0, rowText), GetElementFromRowText(1, rowText), gradClass);

            string[] leaderElement = GetArrayOfElements(rowText);

            for (int i = 4; i < leaderElement.Count(); i++) //list of orgs
            {
                lead.Organizations.Add(leaderElement[i]);
            }


            return lead;
        }

        public List<Leader> CreateLeaders()
        {

            List<Leader> leaders = new List<Leader>();
            for (int i = 0; i < this.CountLines(); i++)
            {
                
                leaders.Add(CreateLeader(GetRow(i)));
            }

            return leaders;
        }


    }
}
