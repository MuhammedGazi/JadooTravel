using AutoMapper;
using JadooTravel.Dtos.TestimonialDtos;
using JadooTravel.Entities;
using JadooTravel.Settings;
using MongoDB.Driver;
using ZstdSharp.Unsafe;

namespace JadooTravel.Services.TestimonialServices
{
    public class TestimonialService : ITestimonialService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Testimonial> _testimonialCollection;
        public TestimonialService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database=client.GetDatabase(_databaseSettings.DatabaseName);
            _testimonialCollection=database.GetCollection<Testimonial>(_databaseSettings.TestimonialCollectionName);
            _mapper = mapper;
        }

        public async Task CreateTestimonialAsync(CreateTestimonialDto dto)
        {
            var value=_mapper.Map<Testimonial>(dto);
            await _testimonialCollection.InsertOneAsync(value);
        }

        public async Task DeleteTestimonialAsync(string id)
        {
            await _testimonialCollection.DeleteOneAsync(x=>x.TestimonialId==id);
        }

        public async Task<List<ResultTestimonialDto>> GetAllTestimonialAsync()
        {
            var values=await _testimonialCollection.Find(x=>true).ToListAsync();
            return _mapper.Map<List<ResultTestimonialDto>>(values);
        }

        public async Task<GetTestimonialByIdDto> GetTestimonialByIdAsync(string id)
        {
            var value=await _testimonialCollection.Find(x=>x.TestimonialId== id).FirstOrDefaultAsync();
            return _mapper.Map<GetTestimonialByIdDto>(value);
        }

        public async Task UpdateTestimonialAsync(UpdateTestimonialDto dto)
        {
            var value=_mapper.Map<Testimonial>(dto);
            await _testimonialCollection.FindOneAndReplaceAsync(x=>x.TestimonialId==dto.TestimonialId,value);
        }
    }
}
