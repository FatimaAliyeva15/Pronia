using Microsoft.AspNetCore.Mvc;

namespace AdminArea_Pronia.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
