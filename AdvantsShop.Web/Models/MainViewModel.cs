using AdvantShop.Domain.Models.ArticleDTOs;
using AdvantShop.Domain.Models.ProductDTOs;
using AdvantShop.Domain.Models.SlideDTOs;

namespace AdvantShop.Web.Models
{
    public class MainViewModel
    {
        public IReadOnlyCollection<SlideDTO> Slides { get; set; }
        public IReadOnlyCollection<ArticleDTO> Articles { get; set; }
        public IReadOnlyCollection<ProductDTO> NewProducts { get; set; }
        public IReadOnlyCollection<ProductDTO> Bestsellers { get; set; }
    }
}
