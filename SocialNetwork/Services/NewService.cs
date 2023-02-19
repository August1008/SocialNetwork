using MongoDB.Driver;
using SocialNetwork.DTOs;
using SocialNetwork.Models;

namespace SocialNetwork.Services
{
    public class NewService : INewService
    {
        private readonly IMongoCollection<New> _news;
        public NewService(ISocialNetworkDatabaseSetting setting, IMongoClient mongoClient) {
            var database = mongoClient.GetDatabase(setting.DatabaseName);
            _news = database.GetCollection<New>(setting.NewCollection);
        }
        public async Task<New> Create(NewDto dto)
        {
            var newNew = new New
            {
                Content = dto.Content,
                CreatedOn = DateTime.Now,
                Email = dto.Email,
                Title = dto.Title,
            };
            await _news.InsertOneAsync(newNew);
            return Task.FromResult(newNew).Result;
        }

        public async Task<IEnumerable<New>> Get() => await _news.Find(e => true).ToListAsync();

        public async Task<New> GetById(string id) => await _news.Find(e => e.Equals(id)).FirstOrDefaultAsync();

        public async Task RemoveAsync(string id)
        {
            await _news.DeleteOneAsync(e => e.Equals(id));
        }

        public async Task<New> Update(NewDto dto)
        {
            var updateNew = new New
            {
                Content = dto.Content,
                CreatedOn = dto.CreatedOn,
                Email = dto.Email,
                Title = dto.Title,
                Id = dto.Id,
            };
            await _news.ReplaceOneAsync(e => e.Id.Equals(updateNew.Id), updateNew);
            return Task.FromResult(updateNew).Result;
        }
    }
}
