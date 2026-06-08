using Xunit;
using ParkSmart.Domain.Entities;

namespace ParkSmart.Tests;

public class ParkingSessionTests
{
    [Fact]
    public void ParkingSession_Should_Create_Correctly()
    {
        var session = new ParkingSession
        {
            Id = 1,
            VehicleRegistration = "ABC123",
            StartTime = DateTime.Now,
            ParkingSpotId = 1
        };

        Assert.Equal("ABC123", session.VehicleRegistration);
        Assert.Equal(1, session.ParkingSpotId);
    }
}