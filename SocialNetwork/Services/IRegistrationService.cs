using SocialNetwork.Models;

namespace SocialNetwork.Services
{
    public interface IRegistrationService
    {
        IEnumerable<Registration> Get();
        Registration GetById(string id);
        bool Create(Registration registration);
        bool Update(Registration registration);
        bool Remove(Registration registration);

    }
}
