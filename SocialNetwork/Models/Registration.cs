using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace SocialNetwork.Models
{
    [BsonIgnoreExtraElements]
    public class Registration
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("email")]
        public string Email { get; set; }
        [BsonElement("password")]
        public string Password { get; set; }
        [BsonElement("phone_number")]
        public string PhoneNumber { get; set; }
        [BsonElement("is_active")]
        public int IsActive { get; set; }
        [BsonElement("is_approved")]
        public int IsApproved { get; set; }

    }
}
