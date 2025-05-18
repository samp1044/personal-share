namespace FileShare.Main.Shared;

public class Result<TResult>
{
    public bool Succeeded { get; } = true;
    
    public TResult Get()
    {
        throw new NotImplementedException();
    }
}