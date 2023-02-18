using SocialNetwork.Models;
using MongoDB.Driver;
using SocialNetwork.DTOs;

namespace SocialNetwork.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IMongoCollection<Registration> _registrations;
        public RegistrationService(ISocialNetworkDatabaseSetting setting, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(setting.DatabaseName);
            _registrations = database.GetCollection<Registration>(setting.RegistrationCollection);
        }
        public async Task<Registration> Create(RegistrationDto dto)
        {
            var registration = new Registration
            {
                Email = dto.Email,
                IsActive = dto.IsActive,
                IsApproved = dto.IsApproved,
                Name = dto.Name,
                Password = dto.Password,
                PhoneNumber = dto.PhoneNumber
            };
            await _registrations.InsertOneAsync(registration);
            return registration;
        }

        public async Task<IEnumerable<Registration>> Get()
        {
            return await _registrations.Find(registration => true).ToListAsync();
        }

        public async Task<Registration> GetById(string id)
        {
            return await _registrations.Find(registration => registration.Id == id).FirstOrDefaultAsync();
        }

        public async Task RemoveAsync(string id)
        {
            _ = await _registrations.DeleteOneAsync(regis => regis.Id == id);
        }

        public async Task<Registration> Update(RegistrationDto dto)
        {
            var registration = new Registration
            {
                Id = dto.Id,
                Email = dto.Email,
                IsActive = dto.IsActive,
                IsApproved = dto.IsApproved,
                Name = dto.Name,
                Password = dto.Password,
                PhoneNumber = dto.PhoneNumber
            };
            await _registrations.ReplaceOneAsync(regis => regis.Id == dto.Id, registration);
            return registration;
        }
    }
}
