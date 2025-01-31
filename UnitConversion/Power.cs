using UnitConversion.ConversionUnits;

namespace UnitConversion;

/// <summary>
/// Represents a power value and provides methods for converting between different power units.
/// </summary>
public class Power : IUnitConverter<PowerUnit, Power>
{
    private readonly double _value;
    private readonly PowerUnit _unit;

    private static readonly Dictionary<PowerUnit, double> ToWattFactor = new()
    {
        { PowerUnit.Watt, 1.0 },
        { PowerUnit.Kilowatt, 1000.0 },
        { PowerUnit.Megawatt, 1_000_000.0 },
        { PowerUnit.Horsepower, 745.7 },
        { PowerUnit.MetricHorsepower, 735.5 }
    };

    /// <summary>
    /// Initializes a new instance of the <see cref="Power"/> class with the specified value and unit.
    /// </summary>
    /// <param name="value">The numerical value of the power.</param>
    /// <param name="unit">The unit of the power.</param>
    public Power(double value, PowerUnit unit)
    {
        _value = value;
        _unit = unit;
    }

    /// <summary>
    /// Gets the numerical value of the power.
    /// </summary>
    public double Value => _value;

    /// <summary>
    /// Gets the unit of the power.
    /// </summary>
    public PowerUnit Unit => _unit;

    /// <summary>
    /// Converts the power to the specified target unit.
    /// </summary>
    /// <param name="targetUnit">The target unit to convert to.</param>
    /// <returns>A new <see cref="Power"/> instance representing the converted value in the target unit.</returns>
    public Power To(PowerUnit targetUnit)
    {
        if (_unit == targetUnit)
        {
            return new Power(_value, targetUnit);
        }

        var valueInWatt = _value * ToWattFactor[_unit];

        var convertedValue = valueInWatt / ToWattFactor[targetUnit];
        return new Power(convertedValue, targetUnit);
    }

    /// <summary>
    /// Returns a string representation of the power.
    /// </summary>
    /// <returns>A string that represents the power.</returns>
    public override string ToString()
    {
        return $"{_value} {_unit}";
    }
}
