using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace SocialNetwork.Models
{
    [BsonIgnoreExtraElements]
    public class Article
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("title")] public string Title { get; set; }
        [BsonElement("content")] public string Content { get;set; }
        [BsonElement("email")] public string Email { get;set; }
        [BsonElement("is_active")] public int IsActive { get;set; }
        [BsonElement("is_approved")] public int IsApproved { get;set; }

    }
}
