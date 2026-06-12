using unit_converter.Converters;
using unit_converter.Exceptions;
using unit_converter.Models;
using unit_converter.Registry;

namespace unit_converter.Services;

public class ConversionService
{

    private readonly UnitRegistry unitRegistry;
    private readonly UnitConverterFactory unitConverterFactory;
    public ConversionService(UnitRegistry unitRegistry, UnitConverterFactory unitConverterFactory)
    {
        this.unitRegistry = unitRegistry;
        this.unitConverterFactory = unitConverterFactory;
    }

    public ConversionResponse Convert(double value, String fromUnit, String toUnit)
    {
        var from = unitRegistry.GetUnit(fromUnit);

        var to = unitRegistry.GetUnit(toUnit);

        if (from.Category != to.Category)
        {
            throw new UnitMismatchException(from.Category.ToString(), to.Category.ToString());
        }

        var converter = unitConverterFactory.GetConverter(from.Category);

        var convertedValue = converter.Convert(value,from,to);

        ConversionResponse response = new()
        {
            ConvertedValue = convertedValue,
            FromUnit = fromUnit,
            ToUnit = toUnit,
            OriginalValue = value
        };

        return response;
    }
}
