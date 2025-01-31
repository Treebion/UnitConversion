using UnitConversion.ConversionUnits;

namespace UnitConversion;

/// <summary>
/// Represents a data size and provides methods for converting between different data units.
/// </summary>
public class Data : IUnitConverter<DataUnit, Data>
{
    private readonly double _value;
    private readonly DataUnit _unit;

    private static readonly Dictionary<DataUnit, double> ToBytesFactor = new()
    {
        { DataUnit.Bit, 0.125 },
        { DataUnit.Byte, 1.0 },
        { DataUnit.Kilobyte, 1024.0 },
        { DataUnit.Megabyte, 1024.0 * 1024.0 },
        { DataUnit.Gigabyte, 1024.0 * 1024.0 * 1024.0 },
        { DataUnit.Terabyte, 1024.0 * 1024.0 * 1024.0 * 1024.0 },
        { DataUnit.Petabyte, 1024.0 * 1024.0 * 1024.0 * 1024.0 * 1024.0 }
    };

    /// <summary>
    /// Initializes a new instance of the <see cref="Data"/> class with the specified value and unit.
    /// </summary>
    /// <param name="value">The numerical value of the data size.</param>
    /// <param name="unit">The unit of the data size.</param>
    public Data(double value, DataUnit unit)
    {
        _value = value;
        _unit = unit;
    }

    /// <summary>
    /// Gets the numerical value of the data size.
    /// </summary>
    public double Value => _value;

    /// <summary>
    /// Gets the unit of the data size.
    /// </summary>
    public DataUnit Unit => _unit;

    /// <summary>
    /// Converts the data size to the specified target unit.
    /// </summary>
    /// <param name="targetUnit">The target unit to convert to.</param>
    /// <returns>A new <see cref="Data"/> instance representing the converted value in the target unit.</returns>
    public Data To(DataUnit targetUnit)
    {
        if (_unit == targetUnit)
        {
            return new Data(_value, targetUnit);
        }

        // Convert to Bytes (base unit)
        var valueInBytes = _value * ToBytesFactor[_unit];

        // Convert from Bytes to the target unit
        var convertedValue = valueInBytes / ToBytesFactor[targetUnit];
        return new Data(convertedValue, targetUnit);
    }

    /// <summary>
    /// Returns a string representation of the data size.
    /// </summary>
    /// <returns>A string that represents the data size.</returns>
    public override string ToString()
    {
        return $"{_value} {Unit}";
    }
}
