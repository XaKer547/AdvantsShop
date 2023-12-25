using AdvantShop.Domain.Services;
using AdvantShop.Web.Helpers;
using AdvantShop.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdvantShop.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new CartViewModel()
            {
                Products = await _cartService.GetCartByUserIdAsync(User.GetUserId())
            };

            return View(model);
        }

        [HttpHead]
        public async Task<IActionResult> ClearCart()
        {
            await _cartService.ClearCartAsync(User.GetUserId());

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(int itemId)
        {
            await _cartService.AddItemToCartAsync(new Domain.Models.CartDTOs.AddCartItemDTO()
            {
                UserId = User.GetUserId(),
                ProductId = itemId
            });

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> RemoveItem(int itemId)
        {
            await _cartService.RemoveItemFromCartAsync(new Domain.Models.CartDTOs.DeleteCartItemDTO()
            {
                UserId = User.GetUserId(),
                ItemId = itemId
            });

            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> ChangeItemAmount(int itemId, int amount)
        {
            await _cartService.SetCartItemAmountAsync(new Domain.Models.CartDTOs.SetCartItemAmountDTO()
            {
                Amount = amount,
                ItemId = itemId,
                UserId = User.GetUserId()
            });

            return Ok();
        }
    }
}
