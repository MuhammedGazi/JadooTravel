using System.Threading.Tasks;
using JadooTravel.Dtos.TripPlanDtos;
using JadooTravel.Services.TripPlanServices;
using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/TripPlan")]
public class TripPlanController : Controller
{
    private readonly ITripPlanService _tripPlanService;

    public TripPlanController(ITripPlanService tripPlanService)
    {
        _tripPlanService = tripPlanService;
    }

    [Route("TripPlanList")]
    public async Task<IActionResult> TripPlanList()
    {
        var values=await _tripPlanService.GetAllTripPlanAsync();
        return View(values);
    }

    [HttpGet]
    [Route("CreateTripPlan")]
    public IActionResult CreateTripPlan()
    {
        return View();
    }
    [HttpPost]
    [Route("CreateTripPlan")]
    public async Task<IActionResult> CreateTripPlan(CreateTripPlanDto dto)
    {
        await _tripPlanService.CreateTripPlanAsync(dto);
        return RedirectToAction("TripPlanList");
    }

    [HttpGet]
    [Route("UpdateTripPlan/{id}")]
    public async Task<IActionResult> UpdateTripPlan(string id)
    {
        var value = await _tripPlanService.GetTripPlanByIdAsync(id);
        return View(value);
    }
    [HttpPost]
    [Route("UpdateTripPlan/{id}")]
    public async Task<IActionResult> UpdateTripPlan(UpdateTripPlanDto dto)
    {
        await _tripPlanService.UpdateTripPlanAsync(dto);
        return RedirectToAction("TripPlanList");
    }

    [Route("DeleteTripPlan/{id}")]
    public async Task<IActionResult> DeleteTripPlan(string id)
    {
        await _tripPlanService.DeleteTripPlanAsync(id);
        return RedirectToAction("TripPlanList");
    }

}
