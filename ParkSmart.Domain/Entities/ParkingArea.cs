using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkSmart.Domain.Entities
{
    public class ParkingArea
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty; 

        public string Address { get; set; } = string.Empty; 
        public int TotalSpots { get; set; } 
            public int AvailableSpots { get; set; }
        public List<ParkingSpot> ParkingSpots { get; set; } = new();

    }
}
