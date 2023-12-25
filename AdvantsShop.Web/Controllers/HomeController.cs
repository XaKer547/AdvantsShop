using AdvantShop.Domain.Services;
using AdvantShop.Web.Models;
using AdvantsShop.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AdvantsShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISlideService _slideService;
        private readonly IProductService _productService;
        private readonly IArticleService _articleService;

        public HomeController(ISlideService slideService,
            IProductService productService,
            IArticleService articleService)
        {
            _slideService = slideService;
            _productService = productService;
            _articleService = articleService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await FillMainViewModel();

            return View(model);
        }

        public IActionResult Cart()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task<MainViewModel> FillMainViewModel()
        {
            return new MainViewModel
            {
                Slides = await _slideService.GetSlidesAsync(),
                NewProducts = await _productService.GetNewProductsAsync(),
                Bestsellers = await _productService.GetBestSellersAsync(),
                Articles = await _articleService.GetLastArticlesAsync(3),
            };
        }
    }
}