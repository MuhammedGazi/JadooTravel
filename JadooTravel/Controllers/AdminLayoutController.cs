using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.Controllers;

public class AdminLayoutController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public PartialViewResult AdminHeaderPartial()
    {
        return PartialView();
    }

    public PartialViewResult AdminSidebarPartial()
    {
        return PartialView();
    }

    public PartialViewResult AdminTopStripPartial()
    {
        return PartialView();
    }
}
