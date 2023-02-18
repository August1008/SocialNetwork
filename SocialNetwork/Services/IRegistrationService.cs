using MongoDB.Driver;
using SocialNetwork.DTOs;
using SocialNetwork.Models;

namespace SocialNetwork.Services
{
    public interface IRegistrationService
    {
        Task<IEnumerable<Registration>> Get();
        Task<Registration> GetById(string id);
        Task<Registration> Create(RegistrationDto dto);
        Task<Registration> Update(RegistrationDto dto);
        Task RemoveAsync(string id);

    }
}
