using ParkSmart.Application.Features.ParkingSessionsCQRS.Queries;
using ParkSmart.Application.Features.ParkingSpotsCQRS.Handlers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ParkSmart.Application.Features.ParkingAreasCQRS.Handlers;
using ParkSmart.Application.Features.ParkingAreasCQRS.Queries;
using ParkSmart.Application.Features.ParkingSpotsCQRS.Queries;
using ParkSmart.Application.Interfaces;
using ParkSmart.Domain.Entities;
using ParkSmart.Infrastructure.Data;
using ParkSmart.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
}); 

builder.Services.AddDbContext<ParkSmartDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IParkingAreaRepository, ParkingAreaRepository>();
builder.Services.AddScoped<IParkingSpotRepository, ParkingSpotRepository>();
builder.Services.AddScoped<IParkingSessionRepository, ParkingSessionRepository>();

builder.Services.AddMediatR(cfg =>
cfg.RegisterServicesFromAssembly(typeof(GetParkingAreasHandler).Assembly));

var app = builder.Build();

app.UseCors("AllowReactApp"); 

if (app.Environment.IsDevelopment())
{
app.UseSwagger();
app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/parkingareas", async (IMediator mediator) =>
{
var parkingAreas = await mediator.Send(new GetParkingAreasQuery());
return Results.Ok(parkingAreas);
});

app.MapGet("/api/parkingareas/{id}", async (ParkSmartDbContext context, int id) =>

{

    var parkingArea = await context.ParkingAreas.FindAsync(id);

    if (parkingArea == null)

    {

        return Results.NotFound();

    }

    return Results.Ok(parkingArea);

}); 

app.MapPost("/api/parkingareas", async (ParkSmartDbContext context, ParkingArea parkingArea) =>
{
context.ParkingAreas.Add(parkingArea);
await context.SaveChangesAsync();

return Results.Created($"/api/parkingareas/{parkingArea.Id}", parkingArea);
});

app.MapPut("/api/parkingareas/{id}", async (ParkSmartDbContext context, int id, ParkingArea updatedArea) =>
{
var parkingArea = await context.ParkingAreas.FindAsync(id);

if (parkingArea == null)
{
return Results.NotFound();
}

parkingArea.Name = updatedArea.Name;
parkingArea.Address = updatedArea.Address;
parkingArea.TotalSpots = updatedArea.TotalSpots;
parkingArea.AvailableSpots = updatedArea.AvailableSpots;

await context.SaveChangesAsync();

return Results.Ok(parkingArea);
});

app.MapDelete("/api/parkingareas/{id}", async (ParkSmartDbContext context, int id) =>
{
var parkingArea = await context.ParkingAreas.FindAsync(id);

if (parkingArea == null)
{
return Results.NotFound();
}

context.ParkingAreas.Remove(parkingArea);
await context.SaveChangesAsync();

return Results.Ok();
});

app.MapPost("/api/parkingspots", async (ParkSmartDbContext context, ParkingSpot parkingSpot) =>
{
context.ParkingSpots.Add(parkingSpot);
await context.SaveChangesAsync();

return Results.Created($"/api/parkingspots/{parkingSpot.Id}", parkingSpot);
});

app.MapGet("/api/parkingspots",async (IMediator mediator) =>
{
var parkingSpots = await mediator.Send(new GetParkingSpotsQuery());
    return Results.Ok(parkingSpots);
});

app.MapGet("/api/parkingspots/{id}", async (ParkSmartDbContext context, int id) =>
{
var parkingSpot = await context.ParkingSpots.FindAsync(id);

if (parkingSpot == null)
{
return Results.NotFound();
}

return Results.Ok(parkingSpot);
});

app.MapPut("/api/parkingspots/{id}", async (ParkSmartDbContext context, int id, ParkingSpot updatedParkingSpot) =>
{
var parkingSpot = await context.ParkingSpots.FindAsync(id);

if (parkingSpot == null)
{
return Results.NotFound();
}

parkingSpot.SpotNumber = updatedParkingSpot.SpotNumber;
parkingSpot.IsAvailable = updatedParkingSpot.IsAvailable;
parkingSpot.ParkingAreaId = updatedParkingSpot.ParkingAreaId;

await context.SaveChangesAsync();

return Results.Ok(parkingSpot);
});

app.MapDelete("/api/parkingspots/{id}", async (ParkSmartDbContext context, int id) =>
{
var parkingSpot = await context.ParkingSpots.FindAsync(id);

if (parkingSpot == null)
{
return Results.NotFound();
}

context.ParkingSpots.Remove(parkingSpot);
await context.SaveChangesAsync();

return Results.Ok();
});

app.MapPost("/api/parkingsessions", async (ParkSmartDbContext context, ParkingSession parkingSession) =>
{
context.ParkingSessions.Add(parkingSession);
await context.SaveChangesAsync();

return Results.Created($"/api/parkingsessions/{parkingSession.Id}", parkingSession);
});

app.MapGet("/api/parkingsessions", async (IMediator mediator) =>
{
var parkingSessions = await mediator.Send(new GetParkingSessionsQuery());
return Results.Ok(parkingSessions);
});

app.MapGet("/api/parkingsessions/{id}", async (ParkSmartDbContext context, int id) =>
{
var parkingSession = await context.ParkingSessions.FindAsync(id);

if (parkingSession == null)
{
return Results.NotFound();
}

return Results.Ok(parkingSession);
});

app.MapPut("/api/parkingsessions/{id}", async (ParkSmartDbContext context, int id, ParkingSession updatedParkingSession) =>
{
var parkingSession = await context.ParkingSessions.FindAsync(id);

if (parkingSession == null)
{
return Results.NotFound();
}

parkingSession.VehicleRegistration = updatedParkingSession.VehicleRegistration;
parkingSession.StartTime = updatedParkingSession.StartTime;
parkingSession.EndTime = updatedParkingSession.EndTime;
parkingSession.ParkingSpotId = updatedParkingSession.ParkingSpotId;

await context.SaveChangesAsync();

return Results.Ok(parkingSession);
});

app.MapDelete("/api/parkingsessions/{id}", async (ParkSmartDbContext context, int id) =>
{
var parkingSession = await context.ParkingSessions.FindAsync(id);

if (parkingSession == null)
{
return Results.NotFound();
}

context.ParkingSessions.Remove(parkingSession);
await context.SaveChangesAsync();

return Results.Ok();
});

app.Run();
