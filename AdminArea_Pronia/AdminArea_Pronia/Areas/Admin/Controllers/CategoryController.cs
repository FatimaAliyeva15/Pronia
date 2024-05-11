using AdminArea_ProniaBusiness.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace AdminArea_Pronia.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
       

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var categories = _categoryService.GetAllCategories();

            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
