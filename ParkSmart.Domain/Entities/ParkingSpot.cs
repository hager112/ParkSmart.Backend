using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkSmart.Domain.Entities
{
    public class ParkingSpot
    { 
        public int Id { get; set; } 
        public string SpotNumber { get; set; } = string.Empty;
        public bool IsAvailable { get; set; } 
        public int ParkingAreaId { get; set; } 
        public ParkingArea ParkingArea { get; set; } = null!; 
    }
}
