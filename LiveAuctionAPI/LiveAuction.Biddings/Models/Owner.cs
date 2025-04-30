using LiveAuction.Common.DTO;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace LiveAuction.Biddings.Models
{
    public class Owner
    {
        [BsonId]
        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid Id { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("firstName")]
        public string FirstName { get; set; }

        [BsonElement("lastName")]
        public string LastName { get; set; }

        public UserInfoDTO ToDTO()
        {
            return new UserInfoDTO
            {
                Id = Id,
                Email = Email,
                FirstName = FirstName,
                LastName = LastName
            };
        }
    }

    public static class OwnerDtoMappingExtensions
    {
        public static Owner? FromDTO(this Owner currentOwner, UserInfoDTO? owner)
        {
            currentOwner ??= new Owner();

            if (owner == null)
            {
                return null;
            }

            currentOwner.Id = owner.Id;
            currentOwner.Email = owner.Email;
            currentOwner.FirstName = owner.FirstName;
            currentOwner.LastName = owner.LastName;

            return currentOwner;
        }
    }
}
