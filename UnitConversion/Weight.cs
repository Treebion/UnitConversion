using UnitConversion.ConversionUnits;

namespace UnitConversion;

/// <summary>
/// Represents a weight value and provides methods for converting between different weight units.
/// </summary>
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

    /// <summary>
    /// Initializes a new instance of the <see cref="Weight"/> class with the specified value and unit.
    /// </summary>
    /// <param name="value">The numerical value of the weight.</param>
    /// <param name="unit">The unit of the weight.</param>
    public Weight(double value, WeightUnit unit)
    {
        _value = value;
        _unit = unit;
    }

    /// <summary>
    /// Gets the numerical value of the weight.
    /// </summary>
    public double Value => _value;

    /// <summary>
    /// Gets the unit of the weight.
    /// </summary>
    public WeightUnit Unit => _unit;

    /// <summary>
    /// Converts the weight to the specified target unit.
    /// </summary>
    /// <param name="targetUnit">The target unit to convert to.</param>
    /// <returns>A new <see cref="Weight"/> instance representing the converted value in the target unit.</returns>
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

    /// <summary>
    /// Returns a string representation of the weight.
    /// </summary>
    /// <returns>A string that represents the weight.</returns>
    public override string ToString()
    {
        return $"{_value} {_unit}";
    }
}
