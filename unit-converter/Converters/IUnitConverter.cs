using unit_converter.Domain;

namespace unit_converter.Converters;

public interface IUnitConverter
{
    double Convert(double value, UnitDefinition from, UnitDefinition to);
}
