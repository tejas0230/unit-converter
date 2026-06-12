using unit_converter.Domain;

namespace unit_converter.Converters;

public class UnitConverterFactory
{
    private readonly LinearUnitConverter linearUnitConverter;
    private readonly TemperatureConverter temperatureConverter;

    public UnitConverterFactory(LinearUnitConverter linearUnitConverter,TemperatureConverter temperatureConverter)
    {
        this.linearUnitConverter = linearUnitConverter;
        this.temperatureConverter = temperatureConverter;
    }

    public IUnitConverter GetConverter(UnitCategory category)
    {
        return category switch
        {
            UnitCategory.Length => linearUnitConverter,
            UnitCategory.Weight => linearUnitConverter,
            UnitCategory.Temperature => temperatureConverter,

            _ => throw new NotSupportedException()
        };
    }

}
