using SocialNetwork.DTOs;
using SocialNetwork.Models;

namespace SocialNetwork.Services
{
    public interface IArticleService
    {
        Task<IEnumerable<Article>> Get();
        Task<Article> GetById(string id);
        Task<Article> Create(ArticleDto dto);
        Task<Article> Update(ArticleDto dto);
        Task RemoveAsync(string id);
    }
}
