namespace UnitConversion;

public interface IUnitConverter<T, TSelf>
{
    TSelf To(T targetUnit);
    double Value { get; }
    T Unit { get; }
}
