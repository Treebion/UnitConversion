using UnitConversion.ConversionUnits;

namespace UnitConversion;

/// <summary>
/// Represents a pressure value and provides methods for converting between different pressure units.
/// </summary>
public class Pressure : IUnitConverter<PressureUnit, Pressure>
{
    private readonly double _value;
    private readonly PressureUnit _unit;

    private static readonly Dictionary<PressureUnit, double> ToPascalFactor = new()
    {
        { PressureUnit.Pascal, 1.0 },
        { PressureUnit.Kilopascal, 1000.0 },
        { PressureUnit.Bar, 100000.0 },
        { PressureUnit.Atmosphere, 101325.0 },
        { PressureUnit.PSI, 6894.76 },
        { PressureUnit.Torr, 133.322 },
        { PressureUnit.Millibar, 100.0 }
    };

    /// <summary>
    /// Initializes a new instance of the <see cref="Pressure"/> class with the specified value and unit.
    /// </summary>
    /// <param name="value">The numerical value of the pressure.</param>
    /// <param name="unit">The unit of the pressure.</param>
    public Pressure(double value, PressureUnit unit)
    {
        _value = value;
        _unit = unit;
    }

    /// <summary>
    /// Gets the numerical value of the pressure.
    /// </summary>
    public double Value => _value;

    /// <summary>
    /// Gets the unit of the pressure.
    /// </summary>
    public PressureUnit Unit => _unit;

    /// <summary>
    /// Converts the pressure to the specified target unit.
    /// </summary>
    /// <param name="targetUnit">The target unit to convert to.</param>
    /// <returns>A new <see cref="Pressure"/> instance representing the converted value in the target unit.</returns>
    public Pressure To(PressureUnit targetUnit)
    {
        if (_unit == targetUnit)
        {
            return new Pressure(_value, targetUnit);
        }

        // Convert to Pascal (base unit)
        var valueInPascal = _value * ToPascalFactor[_unit];

        // Convert from Pascal to the target unit
        var convertedValue = valueInPascal / ToPascalFactor[targetUnit];
        return new Pressure(convertedValue, targetUnit);
    }

    /// <summary>
    /// Returns a string representation of the pressure.
    /// </summary>
    /// <returns>A string that represents the pressure.</returns>
    public override string ToString()
    {
        return $"{_value} {Unit}";
    }
}

