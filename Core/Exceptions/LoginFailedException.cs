namespace Jobs.Core.Exceptions;

public class LoginFailedException : Exception
{
    public LoginFailedException(string? message = "Falha ao realizar o login" ) : base(message)
    {
    }
}