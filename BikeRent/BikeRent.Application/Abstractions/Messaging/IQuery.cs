using BikeRent.Domain.Abstractions;
using MediatR;

namespace BikeRent.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
