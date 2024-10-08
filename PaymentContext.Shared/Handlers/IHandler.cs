using PaymentContext.Shared.Commands;

using ICommand = PaymentContext.Shared.Commands.ICommand;

namespace PaymentContext.Shared.Handlers;
public interface IHandler<T> where T : ICommand
{
    ICommandResult Handle(T command);
}