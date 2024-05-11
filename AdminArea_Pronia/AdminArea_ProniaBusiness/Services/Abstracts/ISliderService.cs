using AdminArea_ProniaCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminArea_ProniaBusiness.Services.Abstracts
{
    public interface ISliderService
    {
        void AddSlider(Slider slider);
        void DeleteSlider(int id);
        void UpdateSlider(int id, Slider newSlider);
        Slider GetSlider(Func<Slider, bool>? func = null);
        List<Slider> GetAllSliders(Func<Slider, bool>? func = null);

    }
}
