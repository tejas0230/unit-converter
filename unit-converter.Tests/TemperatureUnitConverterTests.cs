using unit_converter.Converters;
using unit_converter.Domain;
namespace unit_converter.Tests;

public class TemperatureUnitConverterTests
{
    [Fact]
    public void Convert_CelsiusToFahrenheit_Returns32()
    {
        var converter = new TemperatureConverter();

        var from = new UnitDefinition
        {
            Symbol = "c",
            Category = UnitCategory.Temperature
        };

        var to = new UnitDefinition
        {
            Symbol = "f",
            Category = UnitCategory.Temperature
        };

        var result = converter.Convert(0, from, to);

        Assert.Equal(32, result);
    }

    [Fact]
    public void Convert_FahrenheitToCelsius_Returns100()
    {
        var converter = new TemperatureConverter();

        var from = new UnitDefinition
        {
            Symbol = "f",
            Category = UnitCategory.Temperature
        };

        var to = new UnitDefinition
        {
            Symbol = "c",
            Category = UnitCategory.Temperature
        };

        var result = converter.Convert(212, from, to);

        Assert.Equal(100, result);
    }
}
