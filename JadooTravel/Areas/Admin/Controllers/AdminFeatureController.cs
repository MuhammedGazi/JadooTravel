using JadooTravel.Dtos.FeatureDtos;
using JadooTravel.Services.FeatureServices;
using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/AdminFeature")]
public class AdminFeatureController : Controller
{
    private readonly IFeatureService _featureService;

    public AdminFeatureController(IFeatureService featureService)
    {
        _featureService = featureService;
    }

    [Route("FeatureList")]
    public async Task<IActionResult> FeatureList()
    {
        var value=await _featureService.GetAllFeatureAsync();
        return View(value);
    }

    [HttpGet]
    [Route("CreateFeature")]
    public IActionResult CreateFeature()
    {
        return View();
    }
    [HttpPost]
    [Route("CreateFeature")]
    public async Task<IActionResult> CreateFeature(CreateFeatureDto dto)
    {
        await _featureService.CreateFeature(dto);
        return RedirectToAction("FeatureList");
    }

    [HttpGet]
    [Route("UpdateFeature/{id}")]
    public async Task<IActionResult> UpdateFeature(string id)
    {
        var value=await _featureService.GetFeatureAsync(id);
        return View(value);
    }
    [HttpPost]
    [Route("UpdateFeature/{id}")]
    public async Task<IActionResult> UpdateFeature(UpdateFeatureDto dto)
    {
        await _featureService.UpdateFeatureAsync(dto);
        return RedirectToAction("FeatureList");
    }

    [Route("DeleteFeature/{id}")]
    public async Task<ActionResult> DeleteFeature(string id)
    {
        await _featureService.DeleteFeatureAsync(id);
        return RedirectToAction("FeatureList");
    }
}
