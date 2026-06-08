using Microsoft.EntityFrameworkCore;
using ParkSmart.Application.Interfaces;
using ParkSmart.Domain.Entities;
using ParkSmart.Infrastructure.Data;

namespace ParkSmart.Infrastructure.Repositories
{
    public class ParkingAreaRepository : IParkingAreaRepository
    {
        private readonly ParkSmartDbContext _context;

        public ParkingAreaRepository(ParkSmartDbContext context)
        {
            _context = context;
        }

        public async Task<List<ParkingArea>> GetAllAsync()
        {
            return await _context.ParkingAreas.ToListAsync();
        }

        public async Task<ParkingArea?> GetByIdAsync(int id)
        {
            return await _context.ParkingAreas.FindAsync(id);
        }

        public async Task<ParkingArea> AddAsync(ParkingArea parkingArea)
        {
            _context.ParkingAreas.Add(parkingArea);
            await _context.SaveChangesAsync();
            return parkingArea;
        }

        public async Task<ParkingArea?> UpdateAsync(int id, ParkingArea updatedArea)
        {
            var parkingArea = await _context.ParkingAreas.FindAsync(id);

            if (parkingArea == null)
            {
                return null;
            }

            parkingArea.Name = updatedArea.Name;
            parkingArea.Address = updatedArea.Address;
            parkingArea.TotalSpots = updatedArea.TotalSpots;
            parkingArea.AvailableSpots = updatedArea.AvailableSpots;

            await _context.SaveChangesAsync();
            return parkingArea;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var parkingArea = await _context.ParkingAreas.FindAsync(id);

            if (parkingArea == null)
            {
                return false;
            }

            _context.ParkingAreas.Remove(parkingArea);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}