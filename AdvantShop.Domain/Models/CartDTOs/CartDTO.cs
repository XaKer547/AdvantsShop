namespace AdvantShop.Domain.Models.CartDTOs
{
    public class CartDTO
    {
        public IReadOnlyCollection<ProductCartDTO> Cart { get; set; }
    }
}
