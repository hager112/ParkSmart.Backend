using MediatR;
using ParkSmart.Application.Features.ParkingSessionsCQRS.Queries;
using ParkSmart.Application.Interfaces;
using ParkSmart.Domain.Entities;

namespace ParkSmart.Application.Features.ParkingSessionsCQRS.Handlers;

public class GetParkingSessionsHandler
: IRequestHandler<GetParkingSessionsQuery, List<ParkingSession>>
{
    private readonly IParkingSessionRepository _repository;

    public GetParkingSessionsHandler(IParkingSessionRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ParkingSession>> Handle(
    GetParkingSessionsQuery request,
    CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}