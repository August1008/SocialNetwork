using SocialNetwork.DTOs;
using SocialNetwork.Models;

namespace SocialNetwork.Services
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> Get();
        Task<Event> GetById(string id);
        Task<Event> Create(EventDto dto);
        Task<Event> Update(EventDto dto);
        Task RemoveAsync(string id);
    }
}
