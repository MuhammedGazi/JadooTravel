using System.Threading.Tasks;
using JadooTravel.Dtos.TestimonialDtos;
using JadooTravel.Services.TestimonialServices;
using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminTestimonial")]
    public class AdminTestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;

        public AdminTestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        [Route("TestimonialList")]
        public async Task<IActionResult> TestimonialList()
        {
            var values=await _testimonialService.GetAllTestimonialAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreateTestimonial")]
        public IActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateTestimonial")]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto dto)
        {
            await _testimonialService.CreateTestimonialAsync(dto);
            return RedirectToAction("TestimonialList");
        }

        [HttpGet]
        [Route("UpdateTestimonial/{id}")]
        public async Task<IActionResult> UpdateTestimonial(string id)
        {
           var value= await _testimonialService.GetTestimonialByIdAsync(id);
            return View(value);
        }
        [HttpPost]
        [Route("UpdateTestimonial/{id}")]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto dto)
        {
            await _testimonialService.UpdateTestimonialAsync(dto);
            return RedirectToAction("TestimonialList");
        }

        [Route("DeleteTestimonial/{id}")]
        public async Task<IActionResult> DeleteTestimonial(string id)
        {
            await _testimonialService.DeleteTestimonialAsync(id);
            return RedirectToAction("TestimonialList");
        }
    }
}
