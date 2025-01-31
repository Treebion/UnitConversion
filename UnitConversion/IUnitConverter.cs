namespace UnitConversion;

/// <summary>
/// Defines methods for converting units and retrieving unit information.
/// </summary>
/// <typeparam name="T">The type of the unit.</typeparam>
/// <typeparam name="TSelf">The type of the implementing class.</typeparam>
public interface IUnitConverter<T, TSelf>
{
    /// <summary>
    /// Converts the current value to the specified target unit.
    /// </summary>
    /// <param name="targetUnit">The target unit to convert to.</param>
    /// <returns>A new instance of <typeparamref name="TSelf"/> representing the converted value in the target unit.</returns>
    TSelf To(T targetUnit);

    /// <summary>
    /// Gets the numerical value of the unit.
    /// </summary>
    double Value { get; }

    /// <summary>
    /// Gets the unit type.
    /// </summary>
    T Unit { get; }
}
