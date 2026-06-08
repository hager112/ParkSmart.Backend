using Microsoft.EntityFrameworkCore;
using ParkSmart.Application.Interfaces;
using ParkSmart.Domain.Entities;
using ParkSmart.Infrastructure.Data;

namespace ParkSmart.Infrastructure.Repositories
{
    public class ParkingSpotRepository : IParkingSpotRepository
    {
        private readonly ParkSmartDbContext _context;

        public ParkingSpotRepository(ParkSmartDbContext context)
        {
            _context = context;
        }

        public async Task<List<ParkingSpot>> GetAllAsync()
        {
            return await _context.ParkingSpots.ToListAsync();
        }

        public async Task<ParkingSpot?> GetByIdAsync(int id)
        {
            return await _context.ParkingSpots.FindAsync(id);
        }

        public async Task<ParkingSpot> AddAsync(ParkingSpot parkingSpot)
        {
            _context.ParkingSpots.Add(parkingSpot);
            await _context.SaveChangesAsync();
            return parkingSpot;
        }

        public async Task<ParkingSpot?> UpdateAsync(int id, ParkingSpot updatedSpot)
        {
            var parkingSpot = await _context.ParkingSpots.FindAsync(id);

            if (parkingSpot == null)
            {
                return null;
            }

            parkingSpot.SpotNumber = updatedSpot.SpotNumber;
            parkingSpot.IsAvailable = updatedSpot.IsAvailable;
            parkingSpot.ParkingAreaId = updatedSpot.ParkingAreaId;

            await _context.SaveChangesAsync();
            return parkingSpot;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var parkingSpot = await _context.ParkingSpots.FindAsync(id);

            if (parkingSpot == null)
            {
                return false;
            }

            _context.ParkingSpots.Remove(parkingSpot);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
