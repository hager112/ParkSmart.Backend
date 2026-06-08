using Microsoft.EntityFrameworkCore;
using ParkSmart.Application.Interfaces;
using ParkSmart.Domain.Entities;
using ParkSmart.Infrastructure.Data;

namespace ParkSmart.Infrastructure.Repositories
{
    public class ParkingSessionRepository : IParkingSessionRepository
    {
        private readonly ParkSmartDbContext _context;

        public ParkingSessionRepository(ParkSmartDbContext context)
        {
            _context = context;
        }

        public async Task<List<ParkingSession>> GetAllAsync()
        {
            return await _context.ParkingSessions.ToListAsync();
        }

        public async Task<ParkingSession?> GetByIdAsync(int id)
        {
            return await _context.ParkingSessions.FindAsync(id);
        }

        public async Task<ParkingSession> AddAsync(ParkingSession parkingSession)
        {
            _context.ParkingSessions.Add(parkingSession);
            await _context.SaveChangesAsync();
            return parkingSession;
        }

        public async Task<ParkingSession?> UpdateAsync(int id, ParkingSession updatedSession)
        {
            var parkingSession = await _context.ParkingSessions.FindAsync(id);

            if (parkingSession == null)
            {
                return null;
            }

            parkingSession.VehicleRegistration = updatedSession.VehicleRegistration;
            parkingSession.StartTime = updatedSession.StartTime;
            parkingSession.EndTime = updatedSession.EndTime;
            parkingSession.ParkingSpotId = updatedSession.ParkingSpotId;

            await _context.SaveChangesAsync();
            return parkingSession;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var parkingSession = await _context.ParkingSessions.FindAsync(id);

            if (parkingSession == null)
            {
                return false;
            }

            _context.ParkingSessions.Remove(parkingSession);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}