using AutoMapper;
using JadooTravel.Dtos.DestinationDtos;
using JadooTravel.Dtos.ReservationDtos;
using JadooTravel.Entities;
using JadooTravel.Settings;
using Microsoft.AspNetCore.Routing.Tree;
using MongoDB.Driver;

namespace JadooTravel.Services.ReservationServices
{
    public class ReservationService : IReservationService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Reservation> _reservationCollection;
        private readonly IMongoCollection<Destination> _destinationCollection;

        public ReservationService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _reservationCollection = database.GetCollection<Reservation>(_databaseSettings.ReservationCollectionName);

            var database2 = client.GetDatabase(_databaseSettings.DatabaseName);
            _destinationCollection = database2.GetCollection<Destination>(_databaseSettings.DestinationCollectionName);
            _mapper = mapper;
        }

        public async Task CreateReservationAsync(CreateReservationDto createReservationDto)
        {
            var value = _mapper.Map<Reservation>(createReservationDto);
            await _reservationCollection.InsertOneAsync(value);
        }

        public async Task DeleteReservationAsync(string id)
        {
            await _reservationCollection.DeleteOneAsync(x => x.ReservationId == id);
        }

        public async Task<List<ResultReservationDto>> GetAllReservationAsync()
        {
            var values = await _reservationCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultReservationDto>>(values);
        }

        public async Task<List<GetReservationWithDestination>> GetAllReservationWithDestinationAsync()
        {
            var reservations = await _reservationCollection.Find(x => true).ToListAsync();
            var allDestinations = await _destinationCollection.Find(x => true).ToListAsync();

            var finalResults = reservations.Select(reservation =>
            {
                var destination = allDestinations.FirstOrDefault(d => d.DestinationId == reservation.DestinationId);

                return new GetReservationWithDestination
                {
                    ReservationId = reservation.ReservationId,
                    NameSurname = reservation.NameSurname,
                    Phone = reservation.Phone,
                    Email = reservation.Email,
                    Description = reservation.Description,
                    CityCountry = destination?.CityCountry,
                    Price = destination?.Price ?? 0,
                    DayNight = destination?.DayNight
                };
            }).ToList();

            return finalResults;
        }

        public async Task<List<GetReservationWithDestination>> GetLast5ReservationWithDestinationAsync()
        {
            var reservations = await _reservationCollection.Find(x => true)
                    .SortByDescending(x => x.ReservationId)
                    .Limit(5)
                    .ToListAsync();
            var allDestinations = await _destinationCollection.Find(x => true).ToListAsync();

            var finalResults = reservations.Select(reservation =>
            {
                var destination = allDestinations.FirstOrDefault(d => d.DestinationId == reservation.DestinationId);

                return new GetReservationWithDestination
                {
                    ReservationId = reservation.ReservationId,
                    NameSurname = reservation.NameSurname,
                    Phone = reservation.Phone,
                    Email = reservation.Email,
                    Description = reservation.Description,
                    CityCountry = destination?.CityCountry,
                    Price = destination?.Price ?? 0,
                    DayNight = destination?.DayNight
                };
            }).ToList();

            return finalResults;
        }

        public async Task<GetReservationByIdDto> GetReservationByIdAsync(string id)
        {
            var values = await _reservationCollection.Find(x => x.ReservationId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetReservationByIdDto>(values);
        }

        public async Task UpdateReservationAsync(UpdateReservationDto updateReservationDto)
        {
            var value = _mapper.Map<Reservation>(updateReservationDto);
            await _reservationCollection.FindOneAndReplaceAsync(x => x.ReservationId == updateReservationDto.ReservationId, value);
        }
    }
}
