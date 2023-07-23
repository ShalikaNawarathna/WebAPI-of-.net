using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WebAPI.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("email")]

        public string Email { get; set; } = String.Empty;
        [BsonElement("firstname")]
        public string Firstname { get; set; } = String.Empty;
        [BsonElement("lastname")]
        public string Lastname { get; set; } = String.Empty;
        [BsonElement("password")]
        public string Password { get; set; } = String.Empty;
        [BsonElement("updatedBy")]
        public string UpdatedBy { get; set; } = String.Empty;
        [BsonElement("updatedDate")]
        public DateTime UpdatedDate { get; set; }
        [BsonElement("Status")]
        public MyDataStatus Status { get; set; } //new, Inprogress, Complte

        [BsonElement("isUser")]
        public bool IsUser { get; set; }

        [BsonElement("isAdmin")]
        public bool IsAdmin { get; set; }

        [BsonElement("currentCity")]
        public string CurrentCity { get; set; }

        [BsonElement("spouseName")]
        public string SpouseName { get; set; }

        [BsonElement("personalAdditional")]
        public string PersonalAdditional { get; set; }

    }
}
