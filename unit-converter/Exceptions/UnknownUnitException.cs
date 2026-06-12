namespace unit_converter.Exceptions;

public class UnknownUnitException : Exception
{
    public UnknownUnitException(string unit) : base($"Unknown unit '{unit}'")
    {

    }

}
