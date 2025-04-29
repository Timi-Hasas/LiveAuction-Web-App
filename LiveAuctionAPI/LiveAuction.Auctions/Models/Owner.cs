using LiveAuction.Common.DTO;
using MongoDB.Bson.Serialization.Attributes;

namespace LiveAuction.Auctions.Models
{
    public class Owner
    {
        [BsonElement("id")]
        public Guid Id { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("firstName")]
        public string FirstName { get; set; }

        [BsonElement("lastName")]
        public string LastName { get; set; }

        [BsonElement("birthDate")]
        public DateTime BirthDate { get; set; }

        public UserDTO ToDTO()
        {
            return new UserDTO
            {
                Id = Id,
                BirthDate = BirthDate,
                Email = Email,
                FirstName = FirstName,
                LastName = LastName
            };
        }
    }

    public static class OwnerDtoMappingExtensions
    {
        public static Owner? FromDTO(this Owner currentOwner, UserDTO? owner)
        {
            currentOwner ??= new Owner();

            if (owner == null)
            {
                return null;
            }

            currentOwner.Id = owner.Id;
            currentOwner.BirthDate = owner.BirthDate;
            currentOwner.Email = owner.Email;
            currentOwner.FirstName = owner.FirstName;
            currentOwner.LastName = owner.LastName;

            return currentOwner;
        }
    }
}
