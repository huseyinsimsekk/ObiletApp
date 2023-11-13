using Newtonsoft.Json;

namespace ObiletApp.Models.RequestModels
{
    public class ObiletApiRequestModel
    {
        public object Data { get; set; }

        [JsonProperty("device-session")]
        public DeviceSessionModel DeviceSession { get; set; }
        public DateTime Date { get; set; }
        public string Language { get; set; }
    }
}
