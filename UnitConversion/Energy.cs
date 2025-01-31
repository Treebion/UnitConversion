using UnitConversion.ConversionUnits;

namespace UnitConversion;

/// <summary>
/// Represents an energy value and provides methods for converting between different energy units.
/// </summary>
public class Energy : IUnitConverter<EnergyUnit, Energy>
{
    private readonly double _value;
    private readonly EnergyUnit _unit;

    private static readonly Dictionary<EnergyUnit, double> ToJoulesFactor = new()
    {
        { EnergyUnit.Joules, 1.0 },
        { EnergyUnit.Kilojoules, 1000.0 },
        { EnergyUnit.Calories, 4.184 },
        { EnergyUnit.Kilocalories, 4184.0 },
        { EnergyUnit.WattHours, 3600.0 },
        { EnergyUnit.KilowattHours, 3.6e6 },
        { EnergyUnit.ElectronVolts, 1.60218e-19 },
        { EnergyUnit.BTU, 1055.06 }
    };

    /// <summary>
    /// Initializes a new instance of the <see cref="Energy"/> class with the specified value and unit.
    /// </summary>
    /// <param name="value">The numerical value of the energy.</param>
    /// <param name="unit">The unit of the energy.</param>
    public Energy(double value, EnergyUnit unit)
    {
        _value = value;
        _unit = unit;
    }

    /// <summary>
    /// Gets the numerical value of the energy.
    /// </summary>
    public double Value => _value;

    /// <summary>
    /// Gets the unit of the energy.
    /// </summary>
    public EnergyUnit Unit => _unit;

    /// <summary>
    /// Converts the energy to the specified target unit.
    /// </summary>
    /// <param name="targetUnit">The target unit to convert to.</param>
    /// <returns>A new <see cref="Energy"/> instance representing the converted value in the target unit.</returns>
    public Energy To(EnergyUnit targetUnit)
    {
        if (_unit == targetUnit)
        {
            return new Energy(_value, targetUnit);
        }

        // Convert to Joules (base unit)
        var valueInJoules = _value * ToJoulesFactor[_unit];

        // Convert from Joules to the target unit
        var convertedValue = valueInJoules / ToJoulesFactor[targetUnit];
        return new Energy(convertedValue, targetUnit);
    }

    /// <summary>
    /// Returns a string representation of the energy.
    /// </summary>
    /// <returns>A string that represents the energy.</returns>
    public override string ToString()
    {
        return $"{_value} {_unit}";
    }
}

