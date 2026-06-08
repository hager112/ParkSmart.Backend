using ParkSmart.Domain.Entities;

namespace ParkSmart.Application.Interfaces
{
    public interface IParkingAreaRepository
    {
        Task<List<ParkingArea>> GetAllAsync();
        Task<ParkingArea?> GetByIdAsync(int id);
        Task<ParkingArea> AddAsync(ParkingArea parkingArea);
        Task<ParkingArea?> UpdateAsync(int id, ParkingArea parkingArea);
        Task<bool> DeleteAsync(int id);
    }
}