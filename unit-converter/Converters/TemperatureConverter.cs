using unit_converter.Domain;
using unit_converter.Exceptions;

namespace unit_converter.Converters;

public class TemperatureConverter : IUnitConverter
{
    public double Convert(double value, UnitDefinition from, UnitDefinition to)
    {
        var kelvin = ToKelvin(value, from.Symbol);
        return FromKelvin(kelvin,to.Symbol);
    }

    private double ToKelvin(double value, string unit)
    {
        return unit switch
        {
            "k" => value,
            "c" => value + 273.15,
            "f" => ((value - 32) * (5.0 / 9.0)) + 273.15,
            _ => throw new UnknownUnitException(unit),
        };
    }

    private double FromKelvin(double value, string unit)
    {
        return unit switch
        {
            "k" => value,
            "c" => value - 273.15,
            "f" => ((value - 273.15) * (9.0 / 5.0)) + 32,
            _  => throw new UnknownUnitException(unit)
        };
    }

}
