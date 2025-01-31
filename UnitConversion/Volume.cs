using UnitConversion.ConversionUnits;

namespace UnitConversion;

/// <summary>
/// Represents a volume value and provides methods for converting between different volume units.
/// </summary>
public class Volume : IUnitConverter<VolumeUnit, Volume>
{
    private readonly double _value;
    private readonly VolumeUnit _unit;

    private static readonly Dictionary<VolumeUnit, double> ToLitresFactor = new()
    {
        { VolumeUnit.USLiquidGallon, 3.78541 },
        { VolumeUnit.USLiquidQuart, 0.946353 },
        { VolumeUnit.USLiquidPint, 0.473176 },
        { VolumeUnit.USLegalCup, 0.24 },
        { VolumeUnit.USFluidOunce, 0.0295735 },
        { VolumeUnit.USTablespoon, 0.0147868 },
        { VolumeUnit.USTeaspoon, 0.00492892 },
        { VolumeUnit.CubicMetre, 1000 },
        { VolumeUnit.Litre, 1 },
        { VolumeUnit.Millilitre, 0.001 },
        { VolumeUnit.ImperialGallon, 4.54609 },
        { VolumeUnit.ImperialQuart, 1.13652 },
        { VolumeUnit.ImperialPint, 0.568261 },
        { VolumeUnit.ImperialCup, 0.284131 },
        { VolumeUnit.ImperialFluidOunce, 0.0284131 },
        { VolumeUnit.ImperialTablespoon, 0.0177582 },
        { VolumeUnit.ImperialTeaspoon, 0.00591939 },
        { VolumeUnit.CubicFoot, 28.3168 },
        { VolumeUnit.CubicInch, 0.0163871 }
    };

    /// <summary>
    /// Initializes a new instance of the <see cref="Volume"/> class with the specified value and unit.
    /// </summary>
    /// <param name="value">The numerical value of the volume.</param>
    /// <param name="fromUnit">The unit of the volume.</param>
    public Volume(double value, VolumeUnit fromUnit)
    {
        _value = value;
        _unit = fromUnit;
    }

    /// <summary>
    /// Gets the numerical value of the volume.
    /// </summary>
    public double Value => _value;

    /// <summary>
    /// Gets the unit of the volume.
    /// </summary>
    public VolumeUnit Unit => _unit;

    /// <summary>
    /// Converts the volume to the specified target unit.
    /// </summary>
    /// <param name="targetUnit">The target unit to convert to.</param>
    /// <returns>A new <see cref="Volume"/> instance representing the converted value in the target unit.</returns>
    public Volume To(VolumeUnit targetUnit)
    {
        if (_unit == targetUnit)
        {
            return new Volume(_value, targetUnit);
        }

        // Convert to litres first
        var valueInLitres = _value * ToLitresFactor[_unit];
        // Convert from litres to the target unit
        var convertedValue = valueInLitres / ToLitresFactor[targetUnit];

        return new Volume(convertedValue, targetUnit);
    }

    /// <summary>
    /// Returns a string representation of the volume.
    /// </summary>
    /// <returns>A string that represents the volume.</returns>
    public override string ToString()
    {
        return $"{_value} {_unit}";
    }
}
