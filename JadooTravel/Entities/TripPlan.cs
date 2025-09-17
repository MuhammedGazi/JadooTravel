using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace JadooTravel.Entities
{
    public class TripPlan
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TripPlanId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
