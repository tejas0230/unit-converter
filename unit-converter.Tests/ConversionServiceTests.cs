using unit_converter.Registry;
using unit_converter.Services;
using unit_converter.Exceptions;

using unit_converter.Converters;
namespace unit_converter.Tests;

public class ConversionServiceTests
{
    [Fact]
    public void Convert_UnknownUnit_ThrowsUnknownUnitException()
    {
        var registry = new UnitRegistry();
        var factory = new UnitConverterFactory(
            new LinearUnitConverter(),
            new TemperatureConverter());

        var service = new ConversionService(
            registry,
            factory);

        Assert.Throws<UnknownUnitException>(() =>
            service.Convert(100, "banana", "m"));
    }

    [Fact]
    public void Convert_MismatchedCategories_ThrowsUnitMismatchException()
    {
        var registry = new UnitRegistry();
        var factory = new UnitConverterFactory(
            new LinearUnitConverter(),
            new TemperatureConverter());

        var service = new ConversionService(
            registry,
            factory);

        Assert.Throws<UnitMismatchException>(() =>
            service.Convert(100, "m", "kg"));
    }
}
