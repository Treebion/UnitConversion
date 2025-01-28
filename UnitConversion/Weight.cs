using UnitConversion.ConversionEnums;

namespace UnitConversion;

public class Weight : IUnitConverter<WeightUnit, Weight>
{
    private readonly double _value;
    private readonly WeightUnit _unit;

    private static readonly Dictionary<WeightUnit, double> ToKilogramsFactor = new()
    {
        { WeightUnit.Grams, 0.001 },
        { WeightUnit.Kilograms, 1.0 },
        { WeightUnit.Milligrams, 0.000001 },
        { WeightUnit.MetricTonnes, 1000.0 },
        { WeightUnit.Pounds, 0.453592 },
        { WeightUnit.Ounces, 0.0283495 },
        { WeightUnit.Stones, 6.35029 },
        { WeightUnit.ImperialTons, 1016.05 },
        { WeightUnit.USTons, 907.18474 }
    };

    public Weight(double value, WeightUnit unit)
    {
        _value = value;
        _unit = unit;
    }

    public double Value => _value;
    public WeightUnit Unit => _unit;

    public Weight To(WeightUnit targetUnit)
    {
        if (_unit == targetUnit)
        {
            return new Weight(_value, targetUnit);
        }

        // Convert to kilograms (base unit)
        var valueInKilograms = _value * ToKilogramsFactor[_unit];

        // Convert from kilograms to the target unit
        var convertedValue = valueInKilograms / ToKilogramsFactor[targetUnit];
        return new Weight(convertedValue, targetUnit);
    }

    public override string ToString()
    {
        return $"{_value} {_unit}";
    }
}