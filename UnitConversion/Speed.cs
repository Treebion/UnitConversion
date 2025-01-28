using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConversion.ConversionEnums;

namespace UnitConversion;

public class Speed : IUnitConverter<SpeedUnit, Speed>
{
    private readonly double _value;
    private readonly SpeedUnit _unit;

    private static readonly Dictionary<SpeedUnit, double> ToMetresPerSecondFactor = new()
    {
        { SpeedUnit.MetresPerSecond, 1 },
        { SpeedUnit.KilometresPerHour, 0.277778 },
        { SpeedUnit.MilesPerHour, 0.44704 },
        { SpeedUnit.Knots, 0.514444 },
        { SpeedUnit.FeetPerSecond, 0.3048 }
    };

    public Speed(double value, SpeedUnit unit)
    {
        _value = value;
        _unit = unit;
    }

    public double Value => _value;
    public SpeedUnit Unit => _unit;

    public Speed To(SpeedUnit targetUnit)
    {
        if (_unit == targetUnit)
        {
            return new Speed(_value, targetUnit);
        }

        // Convert to metres per second first
        var valueInMetresPerSecond = _value * ToMetresPerSecondFactor[_unit];
        // Convert from metres per second to the target unit
        var convertedValue = valueInMetresPerSecond / ToMetresPerSecondFactor[targetUnit];

        return new Speed(convertedValue, targetUnit);
    }

    public override string ToString()
    {
        return $"{_value} {Unit}";
    }
}
