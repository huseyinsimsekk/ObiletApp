
using Newtonsoft.Json;
using ObiletApp.Models.ResponseModels;
using RestSharp;

namespace ObiletApp.Businesses.Services
{
    public static class ApiHelper<T>
    {
        public static T Post(object model, string endpoint)
        {
            var client = new RestClient("https://v2-api.obilet.com/api/");

            var request = new RestRequest(endpoint);
            request.AddHeader("Authorization", "Basic JEcYcEMyantZV095WVc3G2JtVjNZbWx1");
            request.AddJsonBody(JsonConvert.SerializeObject(model));
            var response = client.ExecutePost(request);
            return JsonConvert.DeserializeObject<T>(response.Content!)!;
        }
    }
}
