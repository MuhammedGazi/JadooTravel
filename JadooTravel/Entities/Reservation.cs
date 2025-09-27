using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JadooTravel.Entities
{
    public class Reservation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ReservationId { get; set; }
        public string NameSurname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }


        [BsonRepresentation(BsonType.ObjectId)]
        public string DestinationId { get; set; }

        [BsonIgnoreIfNull]
        public Destination Destination { get; set; }
    }
}
