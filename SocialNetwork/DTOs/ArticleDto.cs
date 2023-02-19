using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SocialNetwork.DTOs
{
    public class ArticleDto
    {

        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Email { get; set; }
        public int IsActive { get; set; }
        public int IsApproved { get; set; }
    }
}
