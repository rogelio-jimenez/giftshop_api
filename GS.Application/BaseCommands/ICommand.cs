

using MediatR;

namespace GS.Application.BaseCommands
{
    public interface ICommand<out T>: IRequest<T>
    {
    }

    public interface ICommand: ICommand<Unit>, IRequest
    {
    }
}
