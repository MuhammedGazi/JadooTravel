using System.Net.WebSockets;
using System.Threading.Tasks;
using JadooTravel.Dtos.ReservationDtos;
using JadooTravel.Dtos.ServiceDtos;
using JadooTravel.Services.ServiceServices;
using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/AdminService")]
public class AdminServiceController : Controller
{
    private readonly IServiceService _serviceService;

    public AdminServiceController(IServiceService serviceService)
    {
        _serviceService = serviceService;
    }

    [Route("ServiceList")]
    public async Task<IActionResult> ServiceList()
    {
        var values=await _serviceService.GetAllServiceAsync();
        return View(values);
    }

    [HttpGet]
    [Route("CreateService")]
    public IActionResult CreateService()
    {
        return View();
    }

    [HttpPost]
    [Route("CreateService")]
    public async Task<IActionResult> CreateService(CreateServiceDto dto)
    {
        await _serviceService.CreateServiceAsync(dto);
        return RedirectToAction("ServiceList");
    }

    [HttpGet]
    [Route("UpdateService/{id}")]
    public async Task<IActionResult> UpdateService(string id)
    {
        var value=await _serviceService.GetServiceByIdAsync(id);
        return View(value);
    }
    [HttpPost]
    [Route("UpdateService/{id}")]
    public async Task<IActionResult> UpdateService(UpdateServiceDto dto)
    {
        await _serviceService.UpdateServiceAsync(dto);
        return RedirectToAction("ServiceList");
    }

    [Route("DeleteService/{id}")]
    public async Task<IActionResult> DeleteService(string id)
    {
        await _serviceService.DeleteServiceAsync(id);
        return RedirectToAction("ServiceList");
    }
}
