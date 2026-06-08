using MediatR;
using ParkSmart.Domain.Entities;

namespace ParkSmart.Application.Features.ParkingSessionsCQRS.Queries;

public record GetParkingSessionsQuery() : IRequest<List<ParkingSession>>;
