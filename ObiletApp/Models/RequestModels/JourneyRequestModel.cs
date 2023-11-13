using Newtonsoft.Json;

namespace ObiletApp.Models.RequestModels
{
    public class JourneyRequestModel
    {
        [JsonProperty("origin-id")]
        public int OriginId { get; set; }
        [JsonProperty("destination-id")]
        public int DestinationId { get; set; }
        [JsonProperty("departure-date")]
        public DateTime DepartureDate { get; set; }
    }
}
