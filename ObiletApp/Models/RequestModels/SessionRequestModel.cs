using Newtonsoft.Json;

namespace ObiletApp.Models.RequestModels
{
    public class SessionRequestModel
    {
        public int Type { get; set; }
        public Connection Connection { get; set; }
        public Browser Browser { get; set; }
    }
    public class Connection
    {
        [JsonProperty("ip-address")]
        public string Ipaddress { get; set; }
        public string Port { get; set; }
    }
    public class Browser
    {
        public string Name { get; set; }
        public string Version { get; set; }
    }
}
