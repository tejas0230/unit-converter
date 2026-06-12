using unit_converter.Domain;
using unit_converter.Exceptions;

namespace unit_converter.Registry;

public class UnitRegistry
{
    private readonly Dictionary<string, UnitDefinition> units =
    new()
    {
        // Length
        {
            "mm",
            new UnitDefinition
            {
                Name = "Millimeter",
                Symbol = "mm",
                Category = UnitCategory.Length,
                Factor = 0.001
            }
        },
        {
            "cm",
            new UnitDefinition
            {
                Name = "Centimeter",
                Symbol = "cm",
                Category = UnitCategory.Length,
                Factor = 0.01
            }
        },
        {
            "m",
            new UnitDefinition
            {
                Name = "Meter",
                Symbol = "m",
                Category = UnitCategory.Length,
                Factor = 1
            }
        },
        {
            "km",
            new UnitDefinition
            {
                Name = "Kilometer",
                Symbol = "km",
                Category = UnitCategory.Length,
                Factor = 1000
            }
        },
        {
            "in",
            new UnitDefinition
            {
                Name = "Inch",
                Symbol = "in",
                Category = UnitCategory.Length,
                Factor = 0.0254
            }
        },
        {
            "ft",
            new UnitDefinition
            {
                Name = "Foot",
                Symbol = "ft",
                Category = UnitCategory.Length,
                Factor = 0.3048
            }
        },
        {
            "yd",
            new UnitDefinition
            {
                Name = "Yard",
                Symbol = "yd",
                Category = UnitCategory.Length,
                Factor = 0.9144
            }
        },
        {
            "mi",
            new UnitDefinition
            {
                Name = "Mile",
                Symbol = "mi",
                Category = UnitCategory.Length,
                Factor = 1609.344
            }
        },

        // Weight
        {
            "mg",
            new UnitDefinition
            {
                Name = "Milligram",
                Symbol = "mg",
                Category = UnitCategory.Weight,
                Factor = 0.001
            }
        },
        {
            "g",
            new UnitDefinition
            {
                Name = "Gram",
                Symbol = "g",
                Category = UnitCategory.Weight,
                Factor = 1
            }
        },
        {
            "kg",
            new UnitDefinition
            {
                Name = "Kilogram",
                Symbol = "kg",
                Category = UnitCategory.Weight,
                Factor = 1000
            }
        },
        {
            "oz",
            new UnitDefinition
            {
                Name = "Ounce",
                Symbol = "oz",
                Category = UnitCategory.Weight,
                Factor = 28.349523125
            }
        },
        {
            "lb",
            new UnitDefinition
            {
                Name = "Pound",
                Symbol = "lb",
                Category = UnitCategory.Weight,
                Factor = 453.59237
            }
        },
        //temperature
        {
            "c",
            new UnitDefinition
            {
                Name = "Celsius",
                Symbol = "c",
                Category = UnitCategory.Temperature,
                Factor = 1
            }
        },
        {
            "f",
            new UnitDefinition
            {
                Name = "Fahrenheit",
                Symbol = "f",
                Category = UnitCategory.Temperature,
                Factor = 1
            }
        },
        {
            "k",
            new UnitDefinition
            {
                Name = "Kelvin",
                Symbol = "k",
                Category = UnitCategory.Temperature,
                Factor = 1
            }
        }
    };

    public UnitDefinition GetUnit(string symbol)
    {
        if (!units.TryGetValue(symbol, out var unit))
        {
            throw new UnknownUnitException(symbol);
        }
        return unit;
    }
}
