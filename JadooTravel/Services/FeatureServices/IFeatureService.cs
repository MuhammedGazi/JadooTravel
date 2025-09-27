using JadooTravel.Dtos.FeatureDtos;

namespace JadooTravel.Services.FeatureServices
{
    public interface IFeatureService
    {
        Task<List<ResultFeatureDto>> GetAllFeatureAsync();
        Task<GetFeatureByIdDto> GetFeatureAsync(string id);

        Task CreateFeature(CreateFeatureDto feature);
        Task UpdateFeatureAsync(UpdateFeatureDto feature);
        Task DeleteFeatureAsync(string id);

    }
}
