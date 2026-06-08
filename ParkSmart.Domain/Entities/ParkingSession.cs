using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkSmart.Domain.Entities
{
    public class ParkingSession
    {
        public int Id { get; set; } 
        public string VehicleRegistration { get; set; } = string.Empty; 
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int ParkingSpotId { get; set; } 
        public ParkingSpot ParkingSpot { get; set; } = null!; 
    }
}
