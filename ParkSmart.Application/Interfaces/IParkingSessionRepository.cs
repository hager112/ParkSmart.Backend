using ParkSmart.Domain.Entities;

namespace ParkSmart.Application.Interfaces
{
    public interface IParkingSessionRepository
    {
        Task<List<ParkingSession>> GetAllAsync();
        Task<ParkingSession?> GetByIdAsync(int id);
        Task<ParkingSession> AddAsync(ParkingSession parkingSession);
        Task<ParkingSession?> UpdateAsync(int id, ParkingSession parkingSession);
        Task<bool> DeleteAsync(int id);
    }
}