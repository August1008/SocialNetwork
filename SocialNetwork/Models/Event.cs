using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace SocialNetwork.Models
{
    [BsonIgnoreExtraElements]
    public class Event
    {
        [BsonId][BsonRepresentation(BsonType.ObjectId)] public string Id { get; set; }
        [BsonElement("title")] public string Title { get; set; }
        [BsonElement("content")] public string Content { get; set; }
        [BsonElement("email")] public string Email { get; set; }
        [BsonElement("is_active")] public int IsActive { get; set; }
        [BsonElement("created_on")] public DateTime CreatedOn { get; set; }

    }
}
