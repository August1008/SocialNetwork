using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SocialNetwork.DTOs
{
    public class NewDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Email { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
