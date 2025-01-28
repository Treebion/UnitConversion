using UnitConversion.ConversionEnums;

namespace UnitConversion;

public class Temperature : IUnitConverter<TemperatureUnit, Temperature>
{
    private readonly double _value;
    private readonly TemperatureUnit _unit;

    public Temperature(double value, TemperatureUnit unit)
    {
        _value = value;
        _unit = unit;
    }

    public double Value => _value;
    public TemperatureUnit Unit => _unit;

    public Temperature To(TemperatureUnit targetUnit)
    {
        if (_unit == targetUnit)
        {
            return new Temperature(_value, targetUnit);
        }

        double convertedValue = _unit switch
        {
            TemperatureUnit.Celsius when targetUnit == TemperatureUnit.Fahrenheit => (_value * 9 / 5) + 32,
            TemperatureUnit.Celsius when targetUnit == TemperatureUnit.Kelvin => _value + 273.15,
            TemperatureUnit.Fahrenheit when targetUnit == TemperatureUnit.Celsius => (_value - 32) * 5 / 9,
            TemperatureUnit.Fahrenheit when targetUnit == TemperatureUnit.Kelvin => ((_value - 32) * 5 / 9) + 273.15,
            TemperatureUnit.Kelvin when targetUnit == TemperatureUnit.Celsius => _value - 273.15,
            TemperatureUnit.Kelvin when targetUnit == TemperatureUnit.Fahrenheit => ((_value - 273.15) * 9 / 5) + 32,
            _ => throw new ArgumentException("Invalid temperature conversion")
        };

        return new Temperature(convertedValue, targetUnit);
    }

    public override string ToString()
    {
        return $"{_value} {_unit}";
    }
}

