namespace UKFast.API.Client.DRaaS.Models
{
    public class HardwarePlan
    {
        [Newtonsoft.Json.JsonProperty("id")]
        public string ID { get; set; }

        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("description")]
        public string Description { get; set; }

        [Newtonsoft.Json.JsonProperty("limits")]
        public HardwarePlanLimit Limits { get; set; }

        [Newtonsoft.Json.JsonProperty("networks")]
        public HardwarePlanNetwork Networks { get; set; }

        [Newtonsoft.Json.JsonProperty("storage")]
        public HardwarePlanStorage[] Storage { get; set; }
    }

    public class HardwarePlanLimit
    {
        [Newtonsoft.Json.JsonProperty("processor")]
        public int Processor { get; set; }

        [Newtonsoft.Json.JsonProperty("memory")]
        public int Memory { get; set; }
    }

    public class HardwarePlanNetwork
    {
        [Newtonsoft.Json.JsonProperty("public")]
        public int Public { get; set; }

        [Newtonsoft.Json.JsonProperty("private")]
        public int Private { get; set; }
    }

    public class HardwarePlanStorage
    {
        [Newtonsoft.Json.JsonProperty("id")]
        public string ID { get; set; }

        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("type")]
        public string Type { get; set; }

        [Newtonsoft.Json.JsonProperty("quota")]
        public int Quota { get; set; }
    }
}