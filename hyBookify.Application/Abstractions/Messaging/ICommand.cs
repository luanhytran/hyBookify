using hyBookify.Domain.Abstractions;
using MediatR;

namespace hyBookify.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>, IBaseCommand
{
    
}


public interface ICommand<TResponse>  : IRequest<Result<TResponse>>, IBaseCommand
{
    
}

public interface IBaseCommand
{
    
}