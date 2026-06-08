using Microsoft.EntityFrameworkCore;
using ParkSmart.Domain.Entities;
using System.Collections.Generic;

namespace ParkSmart.Infrastructure.Data
{
    public class ParkSmartDbContext : DbContext
    {
        public ParkSmartDbContext(DbContextOptions<ParkSmartDbContext> options)
        : base(options)
        {
        }

        public DbSet<ParkingArea> ParkingAreas { get; set; }
        public DbSet<ParkingSpot> ParkingSpots { get; set; }
        public DbSet<ParkingSession> ParkingSessions { get; set; }
    }
}