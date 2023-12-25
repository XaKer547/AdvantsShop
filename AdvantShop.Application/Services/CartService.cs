using AdvantShop.DataAccess.Data;
using AdvantShop.Domain.Models.CartDTOs;
using AdvantShop.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace AdvantShop.Application.Services
{
    public class CartService : ICartService
    {
        private readonly AdvantShopDbContext _context;
        public CartService(AdvantShopDbContext context)
        {
            _context = context;
        }

        public async Task AddItemToCartAsync(AddCartItemDTO item)
        {
            var user = _context.Users.Include(u => u.Cart.Products).SingleOrDefault(u => u.Id == item.UserId);

            if (user == null)
            {
                return;
            }

            var cartProduct = user.Cart.Products.SingleOrDefault(p => p.ProductId == item.ProductId);

            if (cartProduct is null)
            {
                var product = _context.Products.SingleOrDefault(p => p.Id == item.ProductId);

                if (product is null)
                {
                    return;
                }

                user.Cart.Products.Add(new DataAccess.Data.Entities.ProductCart()
                {
                    Product = product,
                    Amount = 1
                });

                _context.Users.Update(user);

                await _context.SaveChangesAsync();

                return;
            }

            cartProduct.Amount++;

            _context.ProductCarts.Update(cartProduct);

            await _context.SaveChangesAsync();
        }

        public async Task ClearCartAsync(int userId)
        {
            var user = _context.Users.Include(u => u.Cart.Products).SingleOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return;
            }

            user.Cart.Products.Clear();

            _context.Users.Update(user);

            await _context.SaveChangesAsync();
        }

        public async Task RemoveItemFromCartAsync(DeleteCartItemDTO item)
        {
            var user = _context.Users.Include(u => u.Cart.Products).SingleOrDefault(u => u.Id == item.UserId);

            if (user == null)
            {
                return;
            }

            var cartProduct = user.Cart.Products.SingleOrDefault(p => p.Id == item.ItemId);

            if (cartProduct is null)
            {
                return;
            }

            user.Cart.Products.Remove(cartProduct);

            _context.Users.Update(user);

            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<ProductCartDTO>> GetCartByUserIdAsync(int userId)
        {
            var user = await _context.Users.Select(u => new
            {
                UserId = u.Id,
                Cart = u.Cart.Products.Select(p => new ProductCartDTO
                {
                    Id = p.Id,
                    Product = new Domain.Models.ProductDTOs.ProductDTO()
                    {
                        Name = p.Product.Name,
                        Price = p.Product.Price,
                        Images = p.Product.ImagePaths.ToArray(),
                    },
                    Amount = p.Amount,
                })
            }).SingleOrDefaultAsync(u => u.UserId == userId);

            if (user is null)
            {
                throw new NullReferenceException();
            }

            return user.Cart.ToArray();
        }

        public async Task SetCartItemAmountAsync(SetCartItemAmountDTO setCartItem)
        {
            var user = _context.Users.Include(u => u.Cart.Products).SingleOrDefault(u => u.Id == setCartItem.UserId);

            if (user is null)
            {
                throw new NullReferenceException();
            }

            var product = user.Cart.Products.SingleOrDefault(p => p.Id == setCartItem.ItemId);

            if (product is null)
            {
                throw new NullReferenceException();
            }

            product.Amount = setCartItem.Amount;

            _context.ProductCarts.Update(product);

            await _context.SaveChangesAsync();
        }
    }
}
