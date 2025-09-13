using hyBookify.Domain.Abstractions;
using MediatR;

namespace hyBookify.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
    
}