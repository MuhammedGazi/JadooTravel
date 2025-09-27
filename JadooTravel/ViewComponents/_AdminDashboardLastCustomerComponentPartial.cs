using System.Threading.Tasks;
using JadooTravel.Services.ReservationServices;
using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.ViewComponents
{
    public class _AdminDashboardLastCustomerComponentPartial:ViewComponent
    {
        private readonly IReservationService _reservationService;

        public _AdminDashboardLastCustomerComponentPartial(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values=await _reservationService.GetLast5ReservationWithDestinationAsync();
            return View(values);
        }
    }
}
