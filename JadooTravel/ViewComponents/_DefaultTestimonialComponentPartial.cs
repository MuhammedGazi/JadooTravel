using System.Threading.Tasks;
using JadooTravel.Services.TestimonialServices;
using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.ViewComponents
{
    public class _DefaultTestimonialComponentPartial:ViewComponent
    {
        private readonly ITestimonialService _testimonialService;

        public _DefaultTestimonialComponentPartial(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value=await _testimonialService.GetAllTestimonialAsync();
            return View(value);
        }
    }
}
