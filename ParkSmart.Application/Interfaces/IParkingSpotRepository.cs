using ParkSmart.Domain.Entities;

namespace ParkSmart.Application.Interfaces
{
    public interface IParkingSpotRepository
    {
        Task<List<ParkingSpot>> GetAllAsync();
        Task<ParkingSpot?> GetByIdAsync(int id);
        Task<ParkingSpot> AddAsync(ParkingSpot parkingSpot);
        Task<ParkingSpot?> UpdateAsync(int id, ParkingSpot parkingSpot);
        Task<bool> DeleteAsync(int id);
    }
}