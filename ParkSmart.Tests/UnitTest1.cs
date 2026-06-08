using Xunit;
using ParkSmart.Domain.Entities;

namespace ParkSmart.Tests;

public class ParkingAreaTests
{
    [Fact]
    public void ParkingArea_Should_Create_Correctly()
    {
        var area = new ParkingArea
        {
            Id = 1,
            Name = "Centrum",
            Address = "Storgatan 1",
            TotalSpots = 100,
            AvailableSpots = 75
        };

        Assert.Equal("Centrum", area.Name);
        Assert.Equal(100, area.TotalSpots);
        Assert.Equal(75, area.AvailableSpots);
    }
}