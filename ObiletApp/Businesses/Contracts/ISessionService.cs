using Microsoft.AspNetCore.Mvc.Filters;
using ObiletApp.Models;
using ObiletApp.Models.RequestModels;
using ObiletApp.Models.ResponseModels;

namespace ObiletApp.Businesses.Contracts
{
    public interface ISessionService
    {
        DeviceSessionModel SetSession(ActionExecutingContext context);
    }
}
