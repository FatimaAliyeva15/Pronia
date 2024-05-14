using AdminArea_ProniaBusiness.Exceptions.Slider;
using AdminArea_ProniaBusiness.Services.Abstracts;
using AdminArea_ProniaCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdminArea_Pronia.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public IActionResult Index()
        {
            var sliders = _sliderService.GetAllSliders();
            return View(sliders);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Slider slider)
        {
         if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                _sliderService.AddSlider(slider);
            }
            catch(FileContentTypeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch(FileSizeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var exsistSlider = _sliderService.GetSlider(x => x.Id == id);
            if(exsistSlider == null) return NotFound();

            try
            {
                _sliderService.DeleteSlider(id);
            }
            catch(EntityNotFoundException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
            }
            catch(AdminArea_ProniaBusiness.Exceptions.Slider.FileNotFoundException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Update(int id)
        {
            var slider = _sliderService.GetSlider(x => x.Id == id);
            if(slider == null) return NotFound();

            return View(slider);
        }

        [HttpPost]
        public IActionResult Update(int id, Slider newSlider)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                _sliderService.UpdateSlider(id, newSlider);
            }
            catch(EntityNotFoundException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch(FileContentTypeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch(FileSizeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }


    }
}
