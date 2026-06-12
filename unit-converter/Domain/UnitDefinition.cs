namespace unit_converter.Domain;

public class UnitDefinition
{
    public string Name { get; set; } = string.Empty;

    public string Symbol { get; set; } = string.Empty;

    public UnitCategory Category { get; set; }

    public double Factor {get; set;}
}
