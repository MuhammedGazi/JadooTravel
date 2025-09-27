using AutoMapper;
using JadooTravel.Dtos.FeatureDtos;
using JadooTravel.Entities;
using JadooTravel.Settings;
using MongoDB.Driver;

namespace JadooTravel.Services.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly IMongoCollection<Feature> _featureCollection;
        private readonly IMapper _mapper;

        public FeatureService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client=new MongoClient(_databaseSettings.ConnectionString);
            var database=client.GetDatabase(_databaseSettings.DatabaseName);
            _featureCollection=database.GetCollection<Feature>(_databaseSettings.FeatureCollectionName);
            _mapper = mapper;
        }

        public async Task CreateFeature(CreateFeatureDto feature)
        {
            var value=_mapper.Map<Feature>(feature);
            await _featureCollection.InsertOneAsync(value);
        }

        public async Task DeleteFeatureAsync(string id)
        {
            await _featureCollection.DeleteOneAsync(x=>x.FeatureId==id);
        }

        public async Task<List<ResultFeatureDto>> GetAllFeatureAsync()
        {
           var values=await _featureCollection.Find(x=>true).ToListAsync();
           return _mapper.Map<List<ResultFeatureDto>>(values);
        }

        public async Task<GetFeatureByIdDto> GetFeatureAsync(string id)
        {
            var value=await _featureCollection.Find(x=>x.FeatureId==id).FirstOrDefaultAsync();
            return _mapper.Map<GetFeatureByIdDto>(value);
        }

        public async Task UpdateFeatureAsync(UpdateFeatureDto feature)
        {
            var value = _mapper.Map<Feature>(feature);
            await _featureCollection.FindOneAndReplaceAsync(x=>x.FeatureId==feature.FeatureId, value);
        }
    }
}
