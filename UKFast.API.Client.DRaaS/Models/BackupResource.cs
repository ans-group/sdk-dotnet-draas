using UKFast.API.Client.Models;

namespace UKFast.API.Client.DRaaS.Models
{
    public class BackupResource : ModelBase
    {
        [Newtonsoft.Json.JsonProperty("id")]
        public string ID { get; set; }

        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("quota")]
        public int Quota { get; set; }

        [Newtonsoft.Json.JsonProperty("used_quota")]
        public float UsedQuota { get; set; }
    }
}