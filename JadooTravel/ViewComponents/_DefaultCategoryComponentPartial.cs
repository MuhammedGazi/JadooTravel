using System.Threading.Tasks;
using JadooTravel.Services.ServiceServices;
using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.ViewComponents
{
    public class _DefaultCategoryComponentPartial:ViewComponent
    {
        private readonly IServiceService _service;

        public _DefaultCategoryComponentPartial(IServiceService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value=await _service.GetAllServiceAsync();
            return View(value);
        }
    }
}
