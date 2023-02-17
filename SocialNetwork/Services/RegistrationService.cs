using SocialNetwork.Models;
using MongoDB.Driver;
namespace SocialNetwork.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IMongoCollection<Registration> _registrations;
        public RegistrationService(ISocialNetworkDatabaseSetting setting, IMongoClient mongoClient) {
            var database = mongoClient.GetDatabase(setting.DatabaseName);
            _registrations = database.GetCollection<Registration>(setting.RegistrationCollection);
        }
        public bool Create(Registration registration)
        {
            try
            {
                _registrations.InsertOne(registration);
            } catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<Registration> Get()
        {
            return _registrations.Find(registration => true).ToList();
        }

        public Registration GetById(string id)
        {
            return _registrations.Find(registration => registration.Id == id).FirstOrDefault();
        }

        public bool Remove(Registration registration)
        {
            try
            {
                _registrations.DeleteOne(regis => regis.Id == registration.Id );
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool Update(Registration registration)
        {
            throw new NotImplementedException();
        }
    }
}
