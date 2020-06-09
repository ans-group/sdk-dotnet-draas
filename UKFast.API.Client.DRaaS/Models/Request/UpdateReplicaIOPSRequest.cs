namespace UKFast.API.Client.DRaaS.Models.Request
{
    public class UpdateReplicaIOPSRequest
    {
        [Newtonsoft.Json.JsonProperty("iops_tier_id")]
        public string IOPSTierID { get; set; }
    }
}