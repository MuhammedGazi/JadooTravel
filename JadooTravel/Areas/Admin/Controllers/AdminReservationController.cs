using System.Threading.Tasks;
using JadooTravel.Services.ReservationServices;
using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/AdminReservation")]
public class AdminReservationController : Controller
{
    private readonly IReservationService _reservationService;

    public AdminReservationController(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    [Route("ReservationList")]
    public async Task<IActionResult> ReservationList()
    {
        var values=await _reservationService.GetAllReservationWithDestinationAsync();
        return View(values);
    }

    [Route("DeleteReservation/{id}")]
    public async Task<IActionResult> DeleteReservation(string id)
    {
        await _reservationService.DeleteReservationAsync(id);
        return RedirectToAction("ReservationList");
    }

}
