using AdvantShop.Domain.Models.CartDTOs;

namespace AdvantShop.Web.Models
{
    public class CartViewModel
    {
        public IReadOnlyCollection<ProductCartDTO> Products { get; set; }
    }
}
