using UKFast.API.Client.Models;

namespace UKFast.API.Client.DRaaS.Models
{
    public class Solution : ModelBase
    {
        [Newtonsoft.Json.JsonProperty("id")]
        public string ID { get; set; }

        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("iops_tier_id")]
        public string IOPSTierID { get; set; }

        [Newtonsoft.Json.JsonProperty("billing_type_id")]
        public string BillingTypeID { get; set; }
    }
}