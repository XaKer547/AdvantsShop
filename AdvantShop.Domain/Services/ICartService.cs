using AdvantShop.Domain.Models.CartDTOs;

namespace AdvantShop.Domain.Services
{
    public interface ICartService
    {
        Task<IReadOnlyCollection<ProductCartDTO>> GetCartByUserIdAsync(int userId);
        Task AddItemToCartAsync(AddCartItemDTO item);
        Task RemoveItemFromCartAsync(DeleteCartItemDTO item);
        Task ClearCartAsync(int userId);
        Task SetCartItemAmountAsync(SetCartItemAmountDTO setCartItem);
    }
}
