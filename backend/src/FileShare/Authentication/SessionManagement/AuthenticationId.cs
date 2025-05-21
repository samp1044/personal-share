namespace FileShare.Main.Authentication.SessionManagement;

public class AuthenticationId
{
    private readonly Guid _id;

    private AuthenticationId(Guid id)
    {
        _id = id;
    }

    public static AuthenticationId New() => new AuthenticationId(Guid.NewGuid());
    
    public static AuthenticationId Parse(string id)
    {
        return new AuthenticationId(Guid.Parse(id));
    }
    
    public override string ToString()
    {
        return _id.ToString();
    }
}