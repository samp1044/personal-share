namespace FileShare.Main.Authentication.Application;

public interface ICommandHandler<TCommand, TResult>
{
    public Task<TResult> HandleAsync(TCommand command);
}