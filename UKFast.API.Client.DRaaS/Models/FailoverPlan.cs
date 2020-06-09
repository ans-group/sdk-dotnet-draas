using UKFast.API.Client.Models;

namespace UKFast.API.Client.DRaaS.Models
{
    public class FailoverPlan : ModelBase
    {
        [Newtonsoft.Json.JsonProperty("id")]
        public string ID { get; set; }

        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("description")]
        public string Description { get; set; }

        [Newtonsoft.Json.JsonProperty("status")]
        public string Status { get; set; }

        [Newtonsoft.Json.JsonProperty("vms")]
        public FailoverVM[] VMs { get; set; }
    }

    public class FailoverVM
    {
        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }
    }
}