using Xunit;
using ParkSmart.Domain.Entities;

namespace ParkSmart.Tests;

public class ParkingSpotTests
{
    [Fact]
    public void ParkingSpot_Should_Create_Correctly()
    {
        var spot = new ParkingSpot
        {
            Id = 1,
            SpotNumber = "A1",
            IsAvailable = true,
            ParkingAreaId = 1
        };

        Assert.Equal("A1", spot.SpotNumber);
        Assert.True(spot.IsAvailable);
        Assert.Equal(1, spot.ParkingAreaId);
    }
}
