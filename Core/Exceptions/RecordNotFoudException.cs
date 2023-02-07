namespace Jobs.Core.Exceptions;

public class RecordNotFoudException : Exception
{
    public RecordNotFoudException(string message = "Registro nao encontrado") : base(message)
    {
        
    }
}