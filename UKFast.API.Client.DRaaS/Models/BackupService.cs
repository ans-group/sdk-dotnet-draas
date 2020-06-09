using UKFast.API.Client.Models;

namespace UKFast.API.Client.DRaaS.Models
{
    public class BackupService : ModelBase
    {
        [Newtonsoft.Json.JsonProperty("service")]
        public string Service { get; set; }

        [Newtonsoft.Json.JsonProperty("account_name")]
        public string AccountName { get; set; }

        [Newtonsoft.Json.JsonProperty("gateway")]
        public string Gateway { get; set; }

        [Newtonsoft.Json.JsonProperty("port")]
        public string Port { get; set; }
    }
}