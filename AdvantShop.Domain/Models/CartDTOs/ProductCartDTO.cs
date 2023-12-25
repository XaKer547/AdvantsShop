using AdvantShop.Domain.Models.ProductDTOs;

namespace AdvantShop.Domain.Models.CartDTOs
{
    public class ProductCartDTO
    {
        public int Id { get; set; }
        public ProductDTO Product { get; set; }
        public int Amount { get; set; }
    }
}
