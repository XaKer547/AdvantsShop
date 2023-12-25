using AdvantShop.Domain.Models.ProductDTOs;

namespace AdvantShop.Domain.Services
{
    public interface IProductService
    {
        Task<IReadOnlyCollection<ProductDTO>> GetProducts();
        Task<IReadOnlyCollection<ProductDTO>> GetNewProductsAsync();
        Task<IReadOnlyCollection<ProductDTO>> GetBestSellersAsync();
    }
}
