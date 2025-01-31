using UnitConversion.ConversionUnits;

namespace UnitConversion;

/// <summary>
/// Represents a temperature value and provides methods for converting between different temperature units.
/// </summary>
public class Temperature : IUnitConverter<TemperatureUnit, Temperature>
{
    private readonly double _value;
    private readonly TemperatureUnit _unit;

    /// <summary>
    /// Initializes a new instance of the <see cref="Temperature"/> class with the specified value and unit.
    /// </summary>
    /// <param name="value">The numerical value of the temperature.</param>
    /// <param name="unit">The unit of the temperature.</param>
    public Temperature(double value, TemperatureUnit unit)
    {
        _value = value;
        _unit = unit;
    }

    /// <summary>
    /// Gets the numerical value of the temperature.
    /// </summary>
    public double Value => _value;

    /// <summary>
    /// Gets the unit of the temperature.
    /// </summary>
    public TemperatureUnit Unit => _unit;

    /// <summary>
    /// Converts the temperature to the specified target unit.
    /// </summary>
    /// <param name="targetUnit">The target unit to convert to.</param>
    /// <returns>A new <see cref="Temperature"/> instance representing the converted value in the target unit.</returns>
    public Temperature To(TemperatureUnit targetUnit)
    {
        if (_unit == targetUnit)
        {
            return new Temperature(_value, targetUnit);
        }

        double convertedValue = _unit switch
        {
            TemperatureUnit.Celsius when targetUnit == TemperatureUnit.Fahrenheit => (_value * 9 / 5) + 32,
            TemperatureUnit.Celsius when targetUnit == TemperatureUnit.Kelvin => _value + 273.15,
            TemperatureUnit.Fahrenheit when targetUnit == TemperatureUnit.Celsius => (_value - 32) * 5 / 9,
            TemperatureUnit.Fahrenheit when targetUnit == TemperatureUnit.Kelvin => ((_value - 32) * 5 / 9) + 273.15,
            TemperatureUnit.Kelvin when targetUnit == TemperatureUnit.Celsius => _value - 273.15,
            TemperatureUnit.Kelvin when targetUnit == TemperatureUnit.Fahrenheit => ((_value - 273.15) * 9 / 5) + 32,
            _ => throw new ArgumentException("Invalid temperature conversion")
        };

        return new Temperature(convertedValue, targetUnit);
    }

    /// <summary>
    /// Returns a string representation of the temperature.
    /// </summary>
    /// <returns>A string that represents the temperature.</returns>
    public override string ToString()
    {
        return $"{_value} {_unit}";
    }
}

