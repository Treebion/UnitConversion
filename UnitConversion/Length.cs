using UnitConversion.ConversionUnits;

namespace UnitConversion;

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

    public Length(double value, LengthUnit fromUnit)
    {
        _value = value;
        _unit = fromUnit;
    }

    public double Value => _value;
    public LengthUnit Unit => _unit;

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

    public override string ToString()
    {
        return $"{_value} {_unit}";
    }
}
