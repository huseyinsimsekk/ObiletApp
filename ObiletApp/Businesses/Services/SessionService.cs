using Microsoft.AspNetCore.Mvc.Filters;
using ObiletApp.Businesses.Contracts;
using ObiletApp.Models;
using ObiletApp.Models.RequestModels;
using ObiletApp.Models.ResponseModels;
using UAParser;

namespace ObiletApp.Businesses.Services
{
    public class SessionService : ISessionService
    {
        public DeviceSessionModel SetSession(ActionExecutingContext context)
        {
            var uaParser = Parser.GetDefault();
            ClientInfo clientInfo = uaParser.Parse(context.HttpContext.Request.Headers["User-Agent"].ToString());

            var sessionRequestBody = new SessionRequestModel()
            {
                Browser = new Browser()
                {
                    Name = clientInfo.UserAgent.Family,
                    Version = $"{clientInfo.UserAgent.Major}.{clientInfo.UserAgent.Minor}"
                },
                Connection = new Connection()
                {
                    Ipaddress = context.HttpContext.Connection.RemoteIpAddress.ToString(),
                    Port = context.HttpContext.Connection.RemotePort.ToString(),
                },
                Type = 1

            };
            var response = ApiHelper<ObiletApiResponseModel<DeviceSessionModel>>.Post(sessionRequestBody, "client/getsession");
            return new DeviceSessionModel() { DeviceId = response.Data.DeviceId, SessionId = response.Data.SessionId };
        }
    }
}
