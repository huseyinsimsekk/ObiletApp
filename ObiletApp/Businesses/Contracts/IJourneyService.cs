using ObiletApp.Models.RequestModels;
using ObiletApp.Models.ResponseModels;

namespace ObiletApp.Businesses.Contracts
{
    public interface IJourneyService
    {
        List<Journey> GetJourneys(ISession session, JourneyRequestModel model);
    }
}
