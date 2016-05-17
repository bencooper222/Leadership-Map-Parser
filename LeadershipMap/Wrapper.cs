using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LeadershipMap
{
    abstract class Wrapper
    {
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
