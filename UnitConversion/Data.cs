using UnitConversion.ConversionUnits;

namespace UnitConversion;

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

    public Data(double value, DataUnit unit)
    {
        _value = value;
        _unit = unit;
    }

    public double Value => _value;
    public DataUnit Unit => _unit;

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

    public override string ToString()
    {
        return $"{_value} {Unit}";
    }
}
