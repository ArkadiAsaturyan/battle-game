using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.Data
{
    public class OpponentResponseBody
    {
       [JsonProperty("results")] public OpponentData [] OpponentData { get; set; }
    }    
}
