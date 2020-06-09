namespace UKFast.API.Client.DRaaS.Models.Request
{
    public class ResetBackupServiceCredentialsRequest
    {
        [Newtonsoft.Json.JsonProperty("password")]
        public string Password { get; set; }
    }
}