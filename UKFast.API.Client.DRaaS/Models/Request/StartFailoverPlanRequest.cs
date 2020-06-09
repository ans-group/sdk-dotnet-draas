using System;
using UKFast.API.Client.Json;

namespace UKFast.API.Client.DRaaS.Models.Request
{
    public class StartFailoverPlanRequest
    {
        [Newtonsoft.Json.JsonProperty("start_date", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(DateTimeConverter))]
        public DateTime StartDate { get; set; }
    }
}