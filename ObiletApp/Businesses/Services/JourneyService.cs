using ObiletApp.Businesses.Contracts;
using ObiletApp.Extensions;
using ObiletApp.Models.RequestModels;
using ObiletApp.Models.ResponseModels;
using ObiletApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;

namespace ObiletApp.Businesses.Services
{
    public class JourneyService : IJourneyService
    {
        private IMemoryCache _cache;
        public JourneyService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public List<Journey> GetJourneys(ISession session, JourneyRequestModel model)
        {
            var search = $"{model.OriginId}-{model.DestinationId}_{model.DepartureDate.ToShortDateString()}";
            if (_cache.Get<List<Journey>>(search) is null)
            {
                var sessionResponseModel = session.GetObjectFromJson<DeviceSessionModel>("my_session");
                var busLocationRequestBody = new ObiletApiRequestModel()
                {
                    Date = DateTime.Now,
                    DeviceSession = new DeviceSessionModel()
                    {
                        SessionId = sessionResponseModel.SessionId,
                        DeviceId = sessionResponseModel.DeviceId,
                    },
                    Data = model,
                    Language = "tr-TR"
                };
                var response = ApiHelper<ObiletApiResponseModel<List<JourneyResponseModel>>>.Post(busLocationRequestBody, "journey/getbusjourneys") ?? new ObiletApiResponseModel<List<JourneyResponseModel>>();
                var journeyList = response.Data.Select(m => m.Journey).ToList();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromSeconds(60))
                        .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
                        .SetPriority(CacheItemPriority.Normal)
                        .SetSize(1024);

                _cache.Set(search, journeyList, cacheEntryOptions);
                return journeyList;
            }
            return _cache.Get<List<Journey>>(search);
        }
    }
}
