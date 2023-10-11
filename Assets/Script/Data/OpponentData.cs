using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.Data
{
    public class OpponentData
    {
        [JsonProperty("name")] public Name Name { get; set; }
        [JsonProperty("picture")] public Picture Picture { get; set; }
    }

    public class Name
    {
        [JsonProperty("first")] public string FirstName { get; set; }
    }

    public class Picture 
    {
        [JsonProperty("large")] public string LargePictureUrl { get; set; }
    }
}
