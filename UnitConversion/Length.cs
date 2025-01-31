using UnitConversion.ConversionUnits;

namespace UnitConversion;

/// <summary>
/// Represents a length value and provides methods for converting between different length units.
/// </summary>
public class Length : IUnitConverter<LengthUnit, Length>
{
    private readonly double _value;
    private readonly LengthUnit _unit;

    private static readonly Dictionary<LengthUnit, double> ToMetersFactor = new()
    {
        { LengthUnit.Centimetres, 0.01 },
        { LengthUnit.Feet, 0.3048 },
        { LengthUnit.Inches, 0.0254 },
        { LengthUnit.Kilometres, 1000.0 },
        { LengthUnit.Metres, 1.0 },
        { LengthUnit.Miles, 1609.34 },
        { LengthUnit.Millimetres, 0.001 }
    };

    /// <summary>
    /// Initializes a new instance of the <see cref="Length"/> class with the specified value and unit.
    /// </summary>
    /// <param name="value">The numerical value of the length.</param>
    /// <param name="fromUnit">The unit of the length.</param>
    public Length(double value, LengthUnit fromUnit)
    {
        _value = value;
        _unit = fromUnit;
    }

    /// <summary>
    /// Gets the numerical value of the length.
    /// </summary>
    public double Value => _value;

    /// <summary>
    /// Gets the unit of the length.
    /// </summary>
    public LengthUnit Unit => _unit;

    /// <summary>
    /// Converts the length to the specified target unit.
    /// </summary>
    /// <param name="targetUnit">The target unit to convert to.</param>
    /// <returns>A new <see cref="Length"/> instance representing the converted value in the target unit.</returns>
    public Length To(LengthUnit targetUnit)
    {
        if (_unit == targetUnit)
        {
            return new Length(_value, targetUnit);
        }

        var valueInMeters = _value * ToMetersFactor[_unit];
        var convertedValue = valueInMeters / ToMetersFactor[targetUnit];

        return new Length(convertedValue, targetUnit);
    }

    /// <summary>
    /// Returns a string representation of the length.
    /// </summary>
    /// <returns>A string that represents the length.</returns>
    public override string ToString()
    {
        return $"{_value} {_unit}";
    }
}
