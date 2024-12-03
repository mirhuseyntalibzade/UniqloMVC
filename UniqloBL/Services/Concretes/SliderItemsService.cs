using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniqloBL.Services.Abstractions;
using UniqloDAL.Contexts;
using UniqloDAL.Models;

namespace UniqloBL.Services.Concretes
{
    public class SliderItemsService : ISliderItemService
    {
        readonly UniqloDbContext _context;
        public SliderItemsService(UniqloDbContext context)
        {
            _context = context;
        }

        public async Task CreateSliderItem(SliderItem sliderItem)
        {
            await _context.SliderItems.AddAsync(sliderItem);
            _context.SaveChanges();
        }
        public void UpdateSliderItem(SliderItem updatedSliderItem)
        {
            _context.Update(updatedSliderItem);
            _context.SaveChanges();
        }

        public void DeleteSliderItem(SliderItem sliderItem)
        {
            _context.SliderItems.Remove(sliderItem);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<SliderItem>> GetAllSliderItemsAsync()
        {
            IEnumerable<SliderItem> sliderItems = await _context.SliderItems.ToListAsync();
            return sliderItems;
        }

        public async Task<SliderItem> GetSliderItemAsync(int Id)
        {
            SliderItem sliderItem = await _context.SliderItems.FirstOrDefaultAsync(s=>s.Id==Id);
            return sliderItem;
        }
    }
}
