using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniqloDAL.Models;

namespace UniqloBL.Services.Abstractions
{
    public interface ISliderItemService
    {
        public Task CreateSliderItem(SliderItem sliderItem);
        public Task<IEnumerable<SliderItem>> GetAllSliderItemsAsync();
        public Task<SliderItem> GetSliderItemAsync(int Id);
        public void UpdateSliderItem(SliderItem updatedSliderItem);
        public void DeleteSliderItem(SliderItem sliderItem);
    }
}
