using ErrorOr;
using MediatR;
using Cine.Application.Models.Halls.Queries;

namespace Cine.Application.Models.Halls.Commands;

public record UpdateHallCommand(int Id, string Name, int Capacity, List<int> SchedulesId) : IRequest<ErrorOr<GetHallResult>>;
