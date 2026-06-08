using MediatR;
using ParkSmart.Domain.Entities;

namespace ParkSmart.Application.Features.ParkingAreasCQRS.Queries;

public record GetParkingAreasQuery() : IRequest<List<ParkingArea>>; 