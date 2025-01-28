using UnitConversion.ConversionEnums;

namespace UnitConversion;

public class Area : IUnitConverter<AreaUnit, Area>
{
    private readonly double _value;
    private readonly AreaUnit _unit;

    private static readonly Dictionary<AreaUnit, double> ToSquareMetresFactor = new()
    {
        { AreaUnit.SquareMillimetres, 0.000001 },
        { AreaUnit.SquareCentimetres, 0.0001 },
        { AreaUnit.SquareMetres, 1.0 },
        { AreaUnit.SquareKilometres, 1_000_000.0 },
        { AreaUnit.SquareInches, 0.00064516 },
        { AreaUnit.SquareFeet, 0.092903 },
        { AreaUnit.SquareYards, 0.836127 },
        { AreaUnit.SquareMiles, 2_589_988.11 },
        { AreaUnit.Acres, 4046.86 },
        { AreaUnit.Hectares, 10_000.0 }
    };

    public Area(double value, AreaUnit unit)
    {
        _value = value;
        _unit = unit;
    }

    public double Value => _value;
    public AreaUnit Unit => _unit;

    public Area To(AreaUnit targetUnit)
    {
        if (_unit == targetUnit)
        {
            return new Area(_value, targetUnit);
        }

        // Convert to square metres (base unit)
        var valueInSquareMetres = _value * ToSquareMetresFactor[_unit];

        // Convert from square metres to the target unit
        var convertedValue = valueInSquareMetres / ToSquareMetresFactor[targetUnit];
        return new Area(convertedValue, targetUnit);
    }

    public override string ToString()
    {
        return $"{_value} {_unit}";
    }
}

