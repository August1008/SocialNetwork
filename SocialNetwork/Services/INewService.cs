using SocialNetwork.DTOs;
using SocialNetwork.Models;

namespace SocialNetwork.Services
{
    public interface INewService
    {
        Task<IEnumerable<New>> Get();
        Task<New> GetById(string id);
        Task<New> Create(NewDto dto);
        Task<New> Update(NewDto dto);
        Task RemoveAsync(string id);
    }
}
