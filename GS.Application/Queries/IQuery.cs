using MediatR;

namespace GS.Application.Queries
{
    public interface IQuery<out T>: IRequest<T>
    {
    }
}
