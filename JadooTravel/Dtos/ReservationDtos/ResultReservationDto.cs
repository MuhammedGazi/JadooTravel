using JadooTravel.Entities;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace JadooTravel.Dtos.ReservationDtos
{
    public class ResultReservationDto
    {
        public string ReservationId { get; set; }
        public string NameSurname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string DestinationId { get; set; }
    }
}
