using System.Threading.Tasks;
using JadooTravel.Dtos.DestinationDtos;
using JadooTravel.Services.DestinationServices;
using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.Controllers;

public class DestinationController : Controller
{
    private readonly IDestinationService _destinationService;

    public DestinationController(IDestinationService destinationService)
    {
        _destinationService = destinationService;
    }

    public async Task<IActionResult> DestinationList()
    {
        var values=await _destinationService.GetAllDestinationAsync();
        return View(values);
    }

    [HttpGet]
    public IActionResult CreateDestination()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateDestination(CreateDestinationDto dto)
    {
        await _destinationService.CreateDestinationAsync(dto);
        return RedirectToAction("DestinationList");
    }

    public async Task<IActionResult> DeleteDestination(string id)
    {
        await _destinationService.DeleteDestinationAsync(id);
        return RedirectToAction("DestinationList");
    }

    [HttpGet]
    public async Task<IActionResult> UpdateDestination(string id)
    {
        var value = await _destinationService.GetDestinationByIdAsync(id);
        return View(value);
    }
    [HttpPost]
    public async Task<IActionResult> UpdateDestination(UpdateDestinationDto dto)
    {
        await _destinationService.UpdateDestinationAsync(dto);
        return RedirectToAction("DestinationList");
    }
}
