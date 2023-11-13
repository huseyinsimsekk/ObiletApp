using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using ObiletApp.Businesses.Contracts;
using ObiletApp.Businesses.Services;
using ObiletApp.Extensions;
using ObiletApp.Models;
using ObiletApp.Models.DTOs;
using ObiletApp.Models.RequestModels;
using ObiletApp.Models.ResponseModels;
using System.Diagnostics;
using System.Xml.Linq;

namespace ObiletApp.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IBusService _busService;
        private readonly IJourneyService _journeyService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private IMemoryCache _cache;
        private readonly IValidator<BusLocationDto> _validator;
        public HomeController(IBusService busService, IHttpContextAccessor httpContextAccessor, IMemoryCache cache, IValidator<BusLocationDto> validator, IJourneyService journeyService)
        {
            _busService = busService;
            _httpContextAccessor = httpContextAccessor;
            _cache = cache;
            _validator = validator;
            _journeyService = journeyService;
        }

        public IActionResult Index()
        {
            var busLocations = _busService.GetBusLocationList(_httpContextAccessor.HttpContext.Session);
            ViewBag.BusLocationList = _cache.Get<List<SelectListItem>>("busLocationList");
            ViewBag.Post = false;

            return View(busLocations);
        }

        [HttpPost]
        public IActionResult Index(BusLocationDto model)
        {
            var validator = _validator.Validate(model);
            if (!validator.IsValid)
            {
                if (model.DestinationId == model.OrigionId)
                {
                    ModelState.AddModelError("DestinationId", "Başlangıç ve Varış Noktası Aynı Olamaz");
                }
                ViewBag.Post = true;
                validator.AddToModelState(ModelState);

                _busService.GetBusLocationList(_httpContextAccessor.HttpContext.Session);
                ViewBag.BusLocationList = _cache.Get<List<SelectListItem>>("busLocationList");
                return View(model);
            }
            var firstParam = $"{model.OrigionId}-{model.DestinationId}";
            var secondParam = model.DeparturaDate.ToShortDateString();
            Response.Cookies.AddItemToCookie("Obilet-Direction", firstParam);

            return RedirectToAction("Journey", "Home", new { firstParam, secondParam });
        }

        [HttpGet("[action]/{firstParam}/{secondParam}")]
        public IActionResult Journey(string firstParam, string secondParam)
        {
            var split = firstParam.Split('-');
            if (split.Length != 2)
            {
                return RedirectToAction("Index", "Home");
            }
            var isNumber = Int32.TryParse(split[0], out int origionId);
            var isNumberSecond = Int32.TryParse(split[1], out int destinationId);
            var isValidDate = DateTime.TryParse(secondParam, out var departureDate);

            if (!isNumber || !isNumberSecond || !isValidDate)
            {
                return RedirectToAction("Index", "Home");
            }
            var journeyRequestModel = new JourneyRequestModel()
            {
                DepartureDate = departureDate,
                DestinationId = destinationId,
                OriginId = origionId,
            };
            var search = $"{origionId}-{destinationId}_{departureDate.ToShortDateString()}";

            var model = _journeyService.GetJourneys(_httpContextAccessor.HttpContext.Session, journeyRequestModel);

            var busList = _cache.Get<List<SelectListItem>>("busLocationList");
            if (busList is null)
            {
                _busService.GetBusLocationList(_httpContextAccessor.HttpContext.Session);
            }
            ViewBag.Destination = busList.FirstOrDefault(m => m.Value == destinationId.ToString())?.Text;
            ViewBag.Origin = busList.FirstOrDefault(m => m.Value == origionId.ToString())?.Text;
            ViewBag.DepartureDate = departureDate.ToShortDateString();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}