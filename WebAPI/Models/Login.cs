using MongoDB.Bson.Serialization.Attributes;

namespace WebAPI.Models
{
    public class Login
    {
        [BsonElement("email")]
        public string? Email { get; set; } = string.Empty;

        [BsonElement("password")]
        public string? Password { get; set; } = string.Empty;

        [BsonElement("isUser")]
        public bool IsUser { get; set; }
    }
}
