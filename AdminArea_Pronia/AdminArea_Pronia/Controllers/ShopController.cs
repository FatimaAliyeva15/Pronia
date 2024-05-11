using Microsoft.AspNetCore.Mvc;

namespace AdminArea_Pronia.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
