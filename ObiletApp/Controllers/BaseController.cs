using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using ObiletApp.Businesses.Contracts;
using ObiletApp.Businesses.Services;
using ObiletApp.Extensions;
using ObiletApp.Models;
using ObiletApp.Models.RequestModels;
using ObiletApp.Models.ResponseModels;
using RestSharp;
using UAParser;

namespace ObiletApp.Controllers
{
    public abstract class BaseController : Controller
    {
        private ISessionService _sessionService;
        protected ISessionService SessionService => _sessionService ?? (_sessionService = HttpContext.RequestServices.GetService<ISessionService>());
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetObjectFromJson<DeviceSessionModel>("my_session") == null)
            {
                var data = SessionService.SetSession(context);
                if (data is null)
                {
                    throw new Exception("Session is not created");
                }
                context.HttpContext.Session.SetObjectAsJson("my_session", data);
                
            }
            base.OnActionExecuting(context);
        }
    }
}
