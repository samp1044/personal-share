namespace FileShare.Main.Authentication.SessionManagement;

public class AuthenticationId
{
    private string _id;

    private AuthenticationId(string id)
    {
        _id = id;
    }

    public static AuthenticationId Parse(string id)
    {
        return new AuthenticationId(id);
    }
    
    public override string ToString()
    {
        return _id;
    }
}