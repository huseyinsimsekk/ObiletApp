using Newtonsoft.Json;

namespace ObiletApp.Models.ResponseModels
{
    public class ObiletApiResponseModel<T> where T : class, new()
    {
        public string Status { get; set; }
        public string Message { get; set; }

        [JsonProperty("user-message")]
        public string UserMessage { get; set; }

        [JsonProperty("api-request-id")]
        public string ApiRequestId { get; set; }
        public string Controller { get; set; }
        public T Data { get; set; }
    }
}
