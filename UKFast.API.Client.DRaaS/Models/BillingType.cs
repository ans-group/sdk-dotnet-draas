namespace UKFast.API.Client.DRaaS.Models
{
    public class BillingType
    {
        [Newtonsoft.Json.JsonProperty("id")]
        public string ID { get; set; }

        [Newtonsoft.Json.JsonProperty("type")]
        public string Type { get; set; }
    }
}