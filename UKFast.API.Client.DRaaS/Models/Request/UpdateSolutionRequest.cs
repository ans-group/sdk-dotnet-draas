namespace UKFast.API.Client.DRaaS.Models.Request
{
    public class UpdateSolutionRequest
    {
        [Newtonsoft.Json.JsonProperty("name", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("iops_tier_id", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string IOPSTierID { get; set; }
    }
}