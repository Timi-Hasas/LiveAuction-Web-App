using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LiveAuction.Users.Models
{
    public class User
    {
        [BsonId]
        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid Id { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }

        [BsonElement("firstName")]
        public string FirstName { get; set; }

        [BsonElement("lastName")]
        public string LastName { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        [BsonElement("birthDate")]
        public DateTime BirthDate { get; set; }
    }
}
