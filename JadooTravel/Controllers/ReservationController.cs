using System.Threading.Tasks;
using JadooTravel.Dtos.ReservationDtos;
using JadooTravel.Entities;
using JadooTravel.Services.ReservationServices;
using Microsoft.AspNetCore.Mvc;
using ZstdSharp.Unsafe;

namespace JadooTravel.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationDto dto)
        {
            await _reservationService.CreateReservationAsync(dto);
            return RedirectToAction("Index","Default");
        }
    }
}
