namespace unit_converter.Exceptions;

public class UnitMismatchException : Exception
{
    public UnitMismatchException(string fromCategory, string toCategory) : base($"Cannot convert from {fromCategory} to {toCategory}")
    {
        
    }

}
