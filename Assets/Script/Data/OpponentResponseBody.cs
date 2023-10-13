using Newtonsoft.Json;
namespace Assets.Script.Data
{
    public class OpponentResponseBody
    {
       [JsonProperty("results")] public OpponentData [] OpponentData { get; set; }
    }    
}