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


            string filename = slider.ImgFile.FileName;
            string path = @"C:\Users\Asus\Desktop\TaskAdminArea_Pronia\AdminArea_Pronia\AdminArea_Pronia\wwwroot\Upload\Slider\" + filename;
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                slider.ImgFile.CopyTo(stream);

            }

            slider.ImgUrl = filename;

            if (!ModelState.IsValid)
            {
                return View();
            }

            _sliderService.AddSlider(slider);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var slider = _sliderService.GetSlider(x => x.Id == id);
            string path = @"C:\Users\Asus\Desktop\TaskAdminArea_Pronia\AdminArea_Pronia\AdminArea_Pronia\wwwroot\Upload\Slider\" + slider.ImgUrl;

            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }
            _sliderService.DeleteSlider(id);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Update(int id)
        {
            var slider = _sliderService.GetSlider(x => x.Id == id);
            if(slider == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(slider);
        }

        [HttpPost]
        public IActionResult Update(int id, Slider newSlider)
        {
            if (!ModelState.IsValid)
            {
                return View(newSlider);
            }

            _sliderService.UpdateSlider(id, newSlider);

            return RedirectToAction(nameof(Index));
        }


    }
}
