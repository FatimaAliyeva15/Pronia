using AdminArea_ProniaBusiness.Exceptions;
using AdminArea_ProniaBusiness.Services.Abstracts;
using AdminArea_ProniaCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
            List<Category> categories = _categoryService.GetAllCategories();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {

            try
            {
                _categoryService.AddCategory(category);

            }
            catch (NullReferenceException ex)
            {
                ModelState.AddModelError("Name", ex.Message);
            }
            catch(DuplicateCategoryException ex)
            {
                ModelState.AddModelError("Name", ex.Message);
                return View();
            }
            catch (Exception ex)
            {
                throw;
            }
            
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            try
            {
                _categoryService.DeleteCategory(id);
                
            }
            catch (NullReferenceException ex)
            {
                ModelState.AddModelError("Name", ex.Message);
            }
            catch (Exception ex)
            {
                throw;
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {
            var category = _categoryService.GetCategory(x => x.Id == id);
            if (category == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Update(int id, Category newCategory)
        {

            try
            {
                _categoryService.UpdateCategory(id, newCategory);
            }
            catch (NullReferenceException ex)
            {
                ModelState.AddModelError("Name", ex.Message);
            }
            catch (DuplicateCategoryException ex)
            {
                ModelState.AddModelError("Name", ex.Message);
                return View();
            }
            catch (Exception ex)
            {
                throw;
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}
