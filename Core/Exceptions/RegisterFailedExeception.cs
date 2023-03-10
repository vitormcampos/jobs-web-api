namespace Jobs.Core.Exceptions;

public class RegisterFailedExeception : Exception
{
    public RegisterFailedExeception(string? message = "Falha ao efetuar o registro") : base(message)
    {
    }
}