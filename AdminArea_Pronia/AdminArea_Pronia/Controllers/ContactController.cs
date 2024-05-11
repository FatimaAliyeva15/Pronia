using Microsoft.AspNetCore.Mvc;

namespace AdminArea_Pronia.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
