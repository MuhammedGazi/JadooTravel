using JadooTravel.Dtos.DestinationDtos;
using JadooTravel.Dtos.TripPlanDtos;

namespace JadooTravel.Models
{
    public class BookingViewModel
    {
        public ReservationDestination ReservationDestination { get; set; }
        public List<ResultTripPlanDto> TripPlanDto { get; set; }
    }
}
