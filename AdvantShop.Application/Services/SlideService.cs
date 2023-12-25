using AdvantShop.DataAccess.Data;
using AdvantShop.Domain.Models.SlideDTOs;
using AdvantShop.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace AdvantShop.Application.Services
{
    public class SlideService : ISlideService
    {
        private readonly AdvantShopDbContext _context;
        public SlideService(AdvantShopDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<SlideDTO>> GetSlidesAsync()
        {
            return await _context.Slides.Select(s => new SlideDTO
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                ImagePath = s.ImagePath,
            }).ToArrayAsync();
        }
    }
}
