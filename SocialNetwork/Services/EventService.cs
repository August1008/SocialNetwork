using MongoDB.Driver;
using SocialNetwork.DTOs;
using SocialNetwork.Models;

namespace SocialNetwork.Services
{

    public class EventService : IEventService
    {
        private readonly IMongoCollection<Event> _events;
        public EventService(ISocialNetworkDatabaseSetting setting, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(setting.DatabaseName);
            _events = database.GetCollection<Event>(setting.EventCollection);
        }

        public async Task<Event> Create(EventDto dto)
        {
            var newEvent = new Event
            {
                Content = dto.Content,
                CreatedOn = dto.CreatedOn,
                IsActive = dto.IsActive,
                Email = dto.Email,
                Title = dto.Title,
            };
            await _events.InsertOneAsync(newEvent);
            return Task.FromResult(newEvent).Result;
        }

        public async Task<IEnumerable<Event>> Get() => await _events.Find(e => true).ToListAsync();
        public async Task<Event> GetById(string id) => await _events.FindAsync(e => e.Id == id).Result.FirstOrDefaultAsync();

        public async Task RemoveAsync(string id)
        {
            await _events.DeleteOneAsync(e => e.Equals(id));
        }

        public async Task<Event> Update(EventDto dto)
        {
            var updateEvent = new Event
            {
                Id = dto.Id,
                Content = dto.Content,
                IsActive = dto.IsActive,
                CreatedOn = dto.CreatedOn,
                Email = dto.Email,
                Title = dto.Title,
            };
            await _events.ReplaceOneAsync(e => e.Id.Equals(updateEvent.Id), updateEvent);
            return Task.FromResult(updateEvent).Result;
        }
    }
}
