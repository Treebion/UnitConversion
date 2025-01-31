using UnitConversion.ConversionUnits;

namespace UnitConversion;

/// <summary>
/// Represents a speed value and provides methods for converting between different speed units.
/// </summary>
public class Speed : IUnitConverter<SpeedUnit, Speed>
{
    private readonly double _value;
    private readonly SpeedUnit _unit;

    private static readonly Dictionary<SpeedUnit, double> ToMetresPerSecondFactor = new()
    {
        { SpeedUnit.MetresPerSecond, 1 },
        { SpeedUnit.KilometresPerHour, 0.277778 },
        { SpeedUnit.MilesPerHour, 0.44704 },
        { SpeedUnit.Knots, 0.514444 },
        { SpeedUnit.FeetPerSecond, 0.3048 }
    };

    /// <summary>
    /// Initializes a new instance of the <see cref="Speed"/> class with the specified value and unit.
    /// </summary>
    /// <param name="value">The numerical value of the speed.</param>
    /// <param name="unit">The unit of the speed.</param>
    public Speed(double value, SpeedUnit unit)
    {
        _value = value;
        _unit = unit;
    }

    /// <summary>
    /// Gets the numerical value of the speed.
    /// </summary>
    public double Value => _value;

    /// <summary>
    /// Gets the unit of the speed.
    /// </summary>
    public SpeedUnit Unit => _unit;

    /// <summary>
    /// Converts the speed to the specified target unit.
    /// </summary>
    /// <param name="targetUnit">The target unit to convert to.</param>
    /// <returns>A new <see cref="Speed"/> instance representing the converted value in the target unit.</returns>
    public Speed To(SpeedUnit targetUnit)
    {
        if (_unit == targetUnit)
        {
            return new Speed(_value, targetUnit);
        }

        // Convert to metres per second first
        var valueInMetresPerSecond = _value * ToMetresPerSecondFactor[_unit];
        // Convert from metres per second to the target unit
        var convertedValue = valueInMetresPerSecond / ToMetresPerSecondFactor[targetUnit];

        return new Speed(convertedValue, targetUnit);
    }

    /// <summary>
    /// Returns a string representation of the speed.
    /// </summary>
    /// <returns>A string that represents the speed.</returns>
    public override string ToString()
    {
        return $"{_value} {Unit}";
    }
}
