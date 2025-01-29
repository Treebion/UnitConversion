using UnitConversion.ConversionEnums;

namespace UnitConversion;

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

    public Power(double value, PowerUnit unit)
    {
        _value = value;
        _unit = unit;
    }

    public double Value => _value;
    public PowerUnit Unit => _unit;

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

    public override string ToString()
    {
        return $"{_value} {_unit}";
    }
}
