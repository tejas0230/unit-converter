using unit_converter.Converters;
using unit_converter.Domain;
namespace unit_converter.Tests;

public class LinearUnitConverterTests
{
    [Fact]
    public void Convert_CentimetersToMeters_ReturnsOne()
    {
        // Arrange
        var converter = new LinearUnitConverter();

        var from = new UnitDefinition
        {
            Symbol = "cm",
            Factor = 0.01,
            Category = UnitCategory.Length
        };

        var to = new UnitDefinition
        {
            Symbol = "m",
            Factor = 1,
            Category = UnitCategory.Length
        };

        // Act
        var result = converter.Convert(100, from, to);

        // Assert
        Assert.Equal(1, result);
    }

    
}
