using MongoDB.Driver;
using SocialNetwork.DTOs;
using SocialNetwork.Models;

namespace SocialNetwork.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IMongoCollection<Article> _articles;

        public ArticleService(ISocialNetworkDatabaseSetting setting, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(setting.DatabaseName);
            _articles = database.GetCollection<Article>(setting.ArticleCollection);
        }

        public Task<Article> Create(ArticleDto dto)
        {
            var article = new Article
            {
                Title = dto.Title,
                IsActive = dto.IsActive,
                IsApproved = dto.IsApproved,
                Content = dto.Content,
                Email = dto.Email,
            };
            _articles.InsertOneAsync(article);
            return Task.FromResult(article);
        }

        public async Task<IEnumerable<Article>> Get() => await _articles.Find(a => true).ToListAsync();

        public async Task<Article> GetById(string id) => await _articles.Find(a => a.Id == id).FirstOrDefaultAsync();

        public async Task RemoveAsync(string id)
        {
            _ = await _articles.DeleteOneAsync(a => a.Id.Equals(id));
        }

        public async Task<Article> Update(ArticleDto dto)
        {
            var article = new Article
            {
                Id= dto.Id,
                Title = dto.Title,
                IsActive = dto.IsActive,
                IsApproved = dto.IsApproved,
                Content = dto.Content,
                Email = dto.Email,
            };
            await _articles.ReplaceOneAsync(a => a.Id.Equals(article.Id), article);
            return Task.FromResult(article).Result;
        }
    }
}
