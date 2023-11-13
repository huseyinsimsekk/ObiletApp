using Newtonsoft.Json;

namespace ObiletApp.Models.ResponseModels
{
    public class BusLocation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Rank { get; set; }
    }
}
