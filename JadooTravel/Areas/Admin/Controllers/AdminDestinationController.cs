using JadooTravel.Dtos.DestinationDtos;
using JadooTravel.Services.DestinationServices;
using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/AdminDestination")]
public class AdminDestinationController : Controller
{
    private readonly IDestinationService _destinationService;

    public AdminDestinationController(IDestinationService destinationService)
    {
        _destinationService = destinationService;
    }

    [Route("DestinationList")]
    public async Task<IActionResult> DestinationList()
    {
        var values = await _destinationService.GetAllDestinationAsync();
        return View(values);
    }

    [HttpGet]
    [Route("CreateDestination")]
    public IActionResult CreateDestination()
    {
        return View();
    }
    [HttpPost]
    [Route("CreateDestination")]
    public async Task<IActionResult> CreateDestination(CreateDestinationDto dto)
    {
        await _destinationService.CreateDestinationAsync(dto);
        return RedirectToAction("DestinationList");
    }

    [Route("DeleteDestination/{id}")]
    public async Task<IActionResult> DeleteDestination(string id)
    {
        await _destinationService.DeleteDestinationAsync(id);
        return RedirectToAction("DestinationList");
    }

    [HttpGet]
    [Route("UpdateDestination/{id}")]
    public async Task<IActionResult> UpdateDestination(string id)
    {
        var value = await _destinationService.GetDestinationByIdAsync(id);
        return View(value);
    }
    [HttpPost]
    [Route("UpdateDestination/{id}")]
    public async Task<IActionResult> UpdateDestination(UpdateDestinationDto dto)
    {
        await _destinationService.UpdateDestinationAsync(dto);
        return RedirectToAction("DestinationList");
    }
}
