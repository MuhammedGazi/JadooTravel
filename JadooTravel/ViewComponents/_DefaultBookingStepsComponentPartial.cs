using System.Threading.Tasks;
using JadooTravel.Dtos.DestinationDtos;
using JadooTravel.Dtos.TripPlanDtos;
using JadooTravel.Entities;
using JadooTravel.Models;
using JadooTravel.Services.DestinationServices;
using JadooTravel.Services.TripPlanServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JadooTravel.ViewComponents
{
    public class _DefaultBookingStepsComponentPartial:ViewComponent
    {
        private readonly IDestinationService _destinationService;
        private readonly ITripPlanService _tripPlanService;

        public _DefaultBookingStepsComponentPartial(IDestinationService destinationService, ITripPlanService tripPlanService)
        {
            _destinationService = destinationService;
            _tripPlanService = tripPlanService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var valuesTripPlan=await _tripPlanService.GetAllTripPlanAsync();
            var values=await _destinationService.GetAllDestinationAsync();
            List<SelectListItem> turListesi = values.Select(d => new SelectListItem
            {
                Value = d.DestinationId,       
                Text = d.CityCountry+" / "+d.DayNight+" / "+d.Price+"₺",
            }).ToList();
            ViewBag.turlar = turListesi;
            var vm = new BookingViewModel
            {
                ReservationDestination = new ReservationDestination(),
                TripPlanDto = valuesTripPlan,
            };
            return View(vm);
        }
    }
}
