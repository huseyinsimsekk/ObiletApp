using Newtonsoft.Json;

namespace ObiletApp.Models
{
    public class DeviceSessionModel
    {
        [JsonProperty("session-id")]
        public string SessionId { get; set; }

        [JsonProperty("device-id")]
        public string DeviceId { get; set; }

        //[JsonProperty("device-type")]
        //public int devicetype { get; set; }

        //[JsonProperty("ip-country")]
        //public string ipcountry { get; set; }
    }
}
