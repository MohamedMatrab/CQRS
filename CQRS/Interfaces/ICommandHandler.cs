namespace CQRS.Interfaces;

public interface ICommandHandler<TCommand>
{
    Task Handle(TCommand command);
}