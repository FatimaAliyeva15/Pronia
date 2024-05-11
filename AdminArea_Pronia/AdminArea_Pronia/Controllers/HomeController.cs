
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AdminArea_Pronia.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
