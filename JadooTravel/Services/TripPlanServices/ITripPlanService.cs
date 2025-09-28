using JadooTravel.Dtos.TripPlanDtos;

namespace JadooTravel.Services.TripPlanServices
{
    public interface ITripPlanService
    {
        Task<List<ResultTripPlanDto>> GetAllTripPlanAsync();
        Task<GetTripPlanByIdDto> GetTripPlanByIdAsync(string id);

        Task CreateTripPlanAsync(CreateTripPlanDto dto);
        Task UpdateTripPlanAsync(UpdateTripPlanDto dto);
        Task DeleteTripPlanAsync(string id);

    }
}
