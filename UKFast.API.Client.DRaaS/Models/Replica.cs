using UKFast.API.Client.Models;

namespace UKFast.API.Client.DRaaS.Models
{
    public class Replica : ModelBase
    {
        [Newtonsoft.Json.JsonProperty("id")]
        public string ID { get; set; }

        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("platform")]
        public string Platform { get; set; }

        [Newtonsoft.Json.JsonProperty("cpu")]
        public int CPU { get; set; }

        [Newtonsoft.Json.JsonProperty("ram")]
        public int RAM { get; set; }

        [Newtonsoft.Json.JsonProperty("disk")]
        public int Disk { get; set; }

        [Newtonsoft.Json.JsonProperty("iops")]
        public int IOPS { get; set; }

        [Newtonsoft.Json.JsonProperty("power")]
        public bool Power { get; set; }
    }
}