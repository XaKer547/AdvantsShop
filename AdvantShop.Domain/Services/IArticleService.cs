using AdvantShop.Domain.Models.ArticleDTOs;

namespace AdvantShop.Domain.Services
{
    public interface IArticleService
    {
        Task<IReadOnlyCollection<ArticleDTO>> GetArticlesAsync();
        Task<IReadOnlyCollection<ArticleDTO>> GetLastArticlesAsync(int amount);
    }
}
