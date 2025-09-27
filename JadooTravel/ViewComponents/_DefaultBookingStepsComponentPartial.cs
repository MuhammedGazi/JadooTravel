using System.Threading.Tasks;
using JadooTravel.Entities;
using JadooTravel.Services.DestinationServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JadooTravel.ViewComponents
{
    public class _DefaultBookingStepsComponentPartial:ViewComponent
    {
        private readonly IDestinationService _destinationService;

        public _DefaultBookingStepsComponentPartial(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values=await _destinationService.GetAllDestinationAsync();
            List<SelectListItem> turListesi = values.Select(d => new SelectListItem
            {
                Value = d.DestinationId,       
                Text = d.CityCountry+" / "+d.DayNight+" / "+d.Price+"₺",
            }).ToList();
            ViewBag.turlar = turListesi;
            return View();
        }
    }
}
