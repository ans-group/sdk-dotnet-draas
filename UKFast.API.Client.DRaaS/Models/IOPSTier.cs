using UKFast.API.Client.Models;

namespace UKFast.API.Client.DRaaS.Models
{
    public class IOPSTier : ModelBase
    {
        [Newtonsoft.Json.JsonProperty("id")]
        public string ID { get; set; }

        [Newtonsoft.Json.JsonProperty("iops")]
        public int IOPSLimit { get; set; }
    }
}