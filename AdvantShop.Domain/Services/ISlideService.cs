using AdvantShop.Domain.Models.SlideDTOs;

namespace AdvantShop.Domain.Services
{
    public interface ISlideService
    {
        Task<IReadOnlyCollection<SlideDTO>> GetSlidesAsync();
    }
}
