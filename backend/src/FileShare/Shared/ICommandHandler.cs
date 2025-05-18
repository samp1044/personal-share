namespace FileShare.Main.Shared;

public interface ICommandHandler<in TCommand>
{
    public Task HandleAsync(TCommand command);
}