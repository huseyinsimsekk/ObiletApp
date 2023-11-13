using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using ObiletApp.Businesses.Contracts;
using ObiletApp.Extensions;
using ObiletApp.Models;
using ObiletApp.Models.DTOs;
using ObiletApp.Models.RequestModels;
using ObiletApp.Models.ResponseModels;
using UAParser;

namespace ObiletApp.Businesses.Services
{
    public class BusService : IBusService
    {
        private IMemoryCache _cache;
        public BusService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public BusLocationDto GetBusLocationList(ISession session, string search = null)
        {
            if (_cache.Get<List<SelectListItem>>("busLocationList") is null)
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
                    Language = "tr-TR"
                };
                var result = ApiHelper<ObiletApiResponseModel<List<BusLocation>>>.Post(busLocationRequestBody, "location/getbuslocations");
                var busLocationList = result.Data
                                    .OrderBy(m => m.Rank)
                                    .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name })
                                    .ToList();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromSeconds(60))
                        .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
                        .SetPriority(CacheItemPriority.Normal)
                        .SetSize(1024);

                _cache.Set("busLocationList", busLocationList, cacheEntryOptions);
            }
            return new BusLocationDto() { DeparturaDate = DateTime.Now.AddDays(1) };
        }
    }
}
