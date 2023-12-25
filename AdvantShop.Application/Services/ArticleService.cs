using AdvantShop.DataAccess.Data;
using AdvantShop.Domain.Models.ArticleDTOs;
using AdvantShop.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace AdvantShop.Application.Services
{
    public class ArticleService : IArticleService
    {
        private readonly AdvantShopDbContext _context;
        public ArticleService(AdvantShopDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<ArticleDTO>> GetArticlesAsync()
        {
            return await _context.Articles.Select(a => new ArticleDTO
            {
                Id = a.Id,
                Title = a.Title,
                Description = a.Description,
                ImagePath = a.ImagePath,
            }).ToArrayAsync();
        }
        public async Task<IReadOnlyCollection<ArticleDTO>> GetLastArticlesAsync(int amount)
        {
            var articles = await GetArticlesAsync();

            return articles.TakeLast(amount).ToArray();
        }
    }
}
