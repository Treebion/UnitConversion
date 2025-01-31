using UnitConversion.ConversionUnits;

namespace UnitConversion;

/// <summary>
/// Represents an area and provides methods for converting between different area units.
/// </summary>
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

    /// <summary>
    /// Initializes a new instance of the <see cref="Area"/> class with the specified value and unit.
    /// </summary>
    /// <param name="value">The numerical value of the area.</param>
    /// <param name="unit">The unit of the area.</param>
    public Area(double value, AreaUnit unit)
    {
        _value = value;
        _unit = unit;
    }

    /// <summary>
    /// Gets the numerical value of the area.
    /// </summary>
    public double Value => _value;

    /// <summary>
    /// Gets the unit of the area.
    /// </summary>
    public AreaUnit Unit => _unit;

    /// <summary>
    /// Converts the area to the specified target unit.
    /// </summary>
    /// <param name="targetUnit">The target unit to convert to.</param>
    /// <returns>A new <see cref="Area"/> instance representing the converted value in the target unit.</returns>
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

    /// <summary>
    /// Returns a string representation of the area.
    /// </summary>
    /// <returns>A string that represents the area.</returns>
    public override string ToString()
    {
        return $"{_value} {_unit}";
    }
}

