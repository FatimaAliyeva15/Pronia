using Microsoft.AspNetCore.Mvc;

namespace AdminArea_Pronia.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
