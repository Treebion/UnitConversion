using UnitConversion.ConversionEnums;

namespace UnitConversion;

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

    public Energy(double value, EnergyUnit unit)
    {
        _value = value;
        _unit = unit;
    }

    public double Value => _value;
    public EnergyUnit Unit => _unit;

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

    public override string ToString()
    {
        return $"{_value} {_unit}";
    }
}

