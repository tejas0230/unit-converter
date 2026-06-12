using unit_converter.Domain;

namespace unit_converter.Converters;

public class LinearUnitConverter : IUnitConverter
{
    public double Convert(double value, UnitDefinition from, UnitDefinition to)
    {
        return (value * from.Factor) / to.Factor;
    }

}
