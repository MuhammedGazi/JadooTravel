using System.Threading.Tasks;
using JadooTravel.Services.DestinationServices;
using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.ViewComponents
{
    public class _AdminDashboardGraficComponentPartial:ViewComponent
    {
        private readonly IDestinationService _destinationService;

        public _AdminDashboardGraficComponentPartial(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _destinationService.GetGraficDestinationAsync();
            return View(values);
        }
    }
}
