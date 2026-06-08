using MediatR;
using ParkSmart.Application.Features.ParkingSpotsCQRS.Queries;
using ParkSmart.Application.Interfaces;
using ParkSmart.Domain.Entities;

namespace ParkSmart.Application.Features.ParkingSpotsCQRS.Handlers;

public class GetParkingSpotsHandler
: IRequestHandler<GetParkingSpotsQuery, List<ParkingSpot>>
{
    private readonly IParkingSpotRepository _repository;

    public GetParkingSpotsHandler(IParkingSpotRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ParkingSpot>> Handle(
    GetParkingSpotsQuery request,
    CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}