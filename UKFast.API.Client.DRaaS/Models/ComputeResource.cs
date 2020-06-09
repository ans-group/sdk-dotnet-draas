using UKFast.API.Client.Models;

namespace UKFast.API.Client.DRaaS.Models
{
    public class ComputeResource : ModelBase
    {
        [Newtonsoft.Json.JsonProperty("id")]
        public string ID { get; set; }

        [Newtonsoft.Json.JsonProperty("hardware_plan_id")]
        public string HardwarePlanID { get; set; }

        [Newtonsoft.Json.JsonProperty("memory")]
        public ComputeMemory Memory { get; set; }

        [Newtonsoft.Json.JsonProperty("cpu")]
        public ComputeCPU CPU { get; set; }

        [Newtonsoft.Json.JsonProperty("storage")]
        public ComputeStorage[] VMs { get; set; }
    }

    public class ComputeMemory
    {
        [Newtonsoft.Json.JsonProperty("used")]
        public float Used { get; set; }

        [Newtonsoft.Json.JsonProperty("limit")]
        public float Limit { get; set; }
    }

    public class ComputeCPU
    {
        [Newtonsoft.Json.JsonProperty("used")]
        public int Used { get; set; }
    }

    public class ComputeStorage
    {
        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("used")]
        public int Used { get; set; }

        [Newtonsoft.Json.JsonProperty("limit")]
        public int Limit { get; set; }
    }
}