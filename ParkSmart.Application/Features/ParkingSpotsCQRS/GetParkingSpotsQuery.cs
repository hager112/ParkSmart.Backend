using MediatR;
using ParkSmart.Domain.Entities;

namespace ParkSmart.Application.Features.ParkingSpotsCQRS.Queries;

public record GetParkingSpotsQuery() : IRequest<List<ParkingSpot>>;

