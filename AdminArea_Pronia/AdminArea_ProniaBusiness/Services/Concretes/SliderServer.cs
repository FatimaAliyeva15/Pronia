using AdminArea_ProniaBusiness.Exceptions.Slider;
using AdminArea_ProniaBusiness.Services.Abstracts;
using AdminArea_ProniaCore.Models;
using AdminArea_ProniaCore.RepositoryAbstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminArea_ProniaBusiness.Services.Concretes
{
    public class SliderServer : ISliderService
    {
        private readonly ISliderRepository _sliderRepository;

        public SliderServer(ISliderRepository sliderRepository)
        {
            _sliderRepository = sliderRepository;
        }

        public void AddSlider(Slider slider)
        {
            if (!slider.ImgFile.ContentType.Contains("image/"))
                throw new FileContentTypeException("ImageFile", "File content type error");

            if (slider.ImgFile.Length > 2097152)
                throw new FileSizeException("ImageFile", "File size error");

            string fileName = slider.ImgFile.FileName;
            string path = @"C:\Users\Asus\Desktop\TaskAdminArea_Pronia\AdminArea_Pronia\AdminArea_Pronia\wwwroot\Upload\Slider\" + fileName;
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                slider.ImgFile.CopyTo(fileStream);
            };
            slider.ImgUrl = fileName;

            _sliderRepository.Add(slider);
            _sliderRepository.Commit();
        }
        public void DeleteSlider(int id)
        {
            var existSlider = _sliderRepository.Get(x => x.Id == id);
            if (existSlider == null)
                throw new EntityNotFoundException("", "Entity not found");

            string path = @"C:\Users\Asus\Desktop\TaskAdminArea_Pronia\AdminArea_Pronia\AdminArea_Pronia\wwwroot\Upload\Slider\" + existSlider.ImgUrl;
            if (!File.Exists(path))
                throw new Exceptions.Slider.FileNotFoundException("ImageFile", "File not found");

            File.Delete(path);

            _sliderRepository.Delete(existSlider);
            _sliderRepository.Commit();
        }

        public List<Slider> GetAllSliders(Func<Slider, bool>? func = null)
        {
            return _sliderRepository.GetAll(func);
        }

        public Slider GetSlider(Func<Slider, bool>? func = null)
        {
            return _sliderRepository.Get(func);

        }
        public void UpdateSlider(int id, Slider newSlider)
        {
            var existSlider = _sliderRepository.Get(x => x.Id == id);
            if (existSlider == null)
                throw new EntityNotFoundException("", "Entity not found");

            if(newSlider.ImgFile != null)
            {
                if (!newSlider.ImgFile.ContentType.Contains("image/"))
                {
                    throw new FileContentTypeException("ImageFile", "File content type error");
                }

                if(newSlider.ImgFile.Length > 2097152)
                {
                    throw new FileSizeException("ImageFile", "File size error");
                }
                string fileName = newSlider.ImgFile.FileName;
                string path = @"C:\Users\Asus\Desktop\TaskAdminArea_Pronia\AdminArea_Pronia\AdminArea_Pronia\wwwroot\Upload\Slider\" + fileName;
                using(FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    newSlider.ImgFile.CopyTo(fileStream);
                }
                newSlider.ImgUrl = fileName;

                existSlider.ImgUrl = newSlider.ImgUrl;
            }

            existSlider.Title = newSlider.Title;
            existSlider.Description = newSlider.Description;
            existSlider.SubTitle = newSlider.SubTitle;
            existSlider.ImgUrl = newSlider.ImgUrl;

            _sliderRepository.Commit();
        }

    }
}
