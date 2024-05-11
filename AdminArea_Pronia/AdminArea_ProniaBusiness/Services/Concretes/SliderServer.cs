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
            _sliderRepository.Add(slider);
            _sliderRepository.Commit();
        }
        public void DeleteSlider(int id)
        {
            var existSlider = _sliderRepository.Get(x => x.Id == id);
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
            {
                
                return;
            }

            existSlider.Title = newSlider.Title;
            existSlider.Description = newSlider.Description;
            existSlider.SubTitle = newSlider.SubTitle;
            existSlider.ImgUrl = newSlider.ImgUrl;

            _sliderRepository.Commit();
        }

    }
}
