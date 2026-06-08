using MediatR;
using ParkSmart.Application.Features.ParkingAreasCQRS.Queries;
using ParkSmart.Application.Interfaces;
using ParkSmart.Domain.Entities;

namespace ParkSmart.Application.Features.ParkingAreasCQRS.Handlers;

public class GetParkingAreasHandler
: IRequestHandler<GetParkingAreasQuery, List<ParkingArea>>
{
    private readonly IParkingAreaRepository _repository;

    public GetParkingAreasHandler(IParkingAreaRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ParkingArea>> Handle(
    GetParkingAreasQuery request,
    CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}
