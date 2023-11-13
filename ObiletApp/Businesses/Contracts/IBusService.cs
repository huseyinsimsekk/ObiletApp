using Microsoft.AspNetCore.Mvc.Filters;
using ObiletApp.Models.DTOs;
using ObiletApp.Models.ResponseModels;

namespace ObiletApp.Businesses.Contracts
{
    public interface IBusService
    {
        BusLocationDto GetBusLocationList(ISession session, string search = null);
    }
}
