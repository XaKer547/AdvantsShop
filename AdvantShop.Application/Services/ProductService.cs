using AdvantShop.DataAccess.Data;
using AdvantShop.Domain.Models.ProductDTOs;
using AdvantShop.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace AdvantShop.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly AdvantShopDbContext _context;
        public ProductService(AdvantShopDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<ProductDTO>> GetBestSellersAsync()
        {
            return await _context.Products.Where(p => p.IsBestSeller).Select(p => new ProductDTO
            {
                Id = p.Id,
                Stock = p.Stock,
                Name = p.Name,
                Price = p.Price,
                Rating = p.Rating,
                Images = p.ImagePaths.ToArray(),
            }).ToArrayAsync();
        }

        public async Task<IReadOnlyCollection<ProductDTO>> GetNewProductsAsync()
        {
            return await _context.Products.Where(p => p.IsNew).Select(p => new ProductDTO
            {
                Id = p.Id,
                Stock = p.Stock,
                Name = p.Name,
                Price = p.Price,
                Rating = p.Rating,
                Images = p.ImagePaths.ToArray(),
            }).ToArrayAsync();
        }

        public async Task<IReadOnlyCollection<ProductDTO>> GetProducts()
        {
            return await _context.Products.Select(p => new ProductDTO
            {
                Id = p.Id,
                Stock = p.Stock,
                Name = p.Name,
                Price = p.Price,
                Rating = p.Rating,
                Images = p.ImagePaths.ToArray(),
            }).ToArrayAsync();
        }
    }
}
