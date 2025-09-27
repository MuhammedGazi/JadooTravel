using JadooTravel.Dtos.FeatureDtos;
using JadooTravel.Dtos.TestimonialDtos;

namespace JadooTravel.Services.TestimonialServices
{
    public interface ITestimonialService
    {
        Task<List<ResultTestimonialDto>> GetAllTestimonialAsync();
        Task<GetTestimonialByIdDto> GetTestimonialByIdAsync(string id);

        Task CreateTestimonialAsync(CreateTestimonialDto dto);
        Task UpdateTestimonialAsync(UpdateTestimonialDto dto);
        Task DeleteTestimonialAsync(string id);
    }
}
