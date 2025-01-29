using UnitConversion.ConversionUnits;

namespace UnitConversion;

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

    public Pressure(double value, PressureUnit unit)
    {
        _value = value;
        _unit = unit;
    }

    public double Value => _value;
    public PressureUnit Unit => _unit;

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

    public override string ToString()
    {
        return $"{_value} {Unit}";
    }
}

