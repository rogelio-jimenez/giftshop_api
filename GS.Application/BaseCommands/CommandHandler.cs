using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GS.Application.BaseCommands
{
    public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        protected abstract Task Handle(TCommand command, CancellationToken cancellationToken);

        async Task<Unit> IRequestHandler<TCommand, Unit>.Handle(TCommand request, CancellationToken cancellationToken)
        {
            await Handle(request, cancellationToken);
            return Unit.Value;
        }
    }
}
