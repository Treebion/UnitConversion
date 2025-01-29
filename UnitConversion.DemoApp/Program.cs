using UnitConversion.ConversionUnits;

namespace UnitConversion.DemoApp;

internal class Program
{
    static void Main(string[] args)
    {
        DemoLength();
        DemoSpeed();
        DemoTemperature();
        DemoWeight();
        DemoArea();
        DemoEnergy();
        DemoPower();
        DemoPressure();
        DemoData();

        Console.ReadLine();
    }

    private static void DemoData()
    {
        var mb = new Data(2048, DataUnit.Megabyte);
        var gb = mb.To(DataUnit.Gigabyte);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Data Conversions");
        Console.ResetColor();
        Console.WriteLine($"{mb} = {gb}");
        Console.WriteLine();
    }

    private static void DemoPressure()
    {
        var bar = new Pressure(2, PressureUnit.Bar);
        var psi = bar.To(PressureUnit.PSI);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Pressure Conversions");
        Console.ResetColor();
        Console.WriteLine($"{bar} = {psi}");
        Console.WriteLine();
    }

    private static void DemoPower()
    {
        var hp = new Power(100, PowerUnit.Horsepower);
        var kw = hp.To(PowerUnit.Kilowatt);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Power Conversions");
        Console.ResetColor();
        Console.WriteLine($"{hp} = {kw}");
        Console.WriteLine();
    }

    private static void DemoEnergy()
    {
        var kwh = new Energy(10, EnergyUnit.KilowattHours);
        var cal = kwh.To(EnergyUnit.Calories);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Energy Conversions");
        Console.ResetColor();
        Console.WriteLine($"{kwh} = {cal}");
        Console.WriteLine();
    }

    private static void DemoArea()
    {
        var sqm = new Area(1000, AreaUnit.SquareMetres);
        var acr = sqm.To(AreaUnit.Acres);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Area Conversions");
        Console.ResetColor();
        Console.WriteLine($"{sqm} = {acr}");
        Console.WriteLine();
    }

    private static void DemoWeight()
    {
        var lb = new Weight(1, WeightUnit.Pounds);
        var oz = lb.To(WeightUnit.Ounces);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Length Conversions");
        Console.ResetColor();
        Console.WriteLine($"{lb} = {oz}");
        Console.WriteLine();
    }

    private static void DemoLength()
    {
        var miles = new Length(100, LengthUnit.Miles);
        var kilometres = miles.To(LengthUnit.Kilometres);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Length Conversions");
        Console.ResetColor();
        Console.WriteLine($"{miles} = {kilometres}");
        Console.WriteLine();
    }

    private static void DemoSpeed()
    {
        var kph = new Speed(100, SpeedUnit.KilometresPerHour);
        var mph = kph.To(SpeedUnit.MilesPerHour);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Speed Conversions");
        Console.ResetColor();
        Console.WriteLine($"{kph} = {mph}");
        Console.WriteLine();
    }

    private static void DemoTemperature()
    {
        var cel = new Temperature(100, TemperatureUnit.Celsius);
        var fah = cel.To(TemperatureUnit.Fahrenheit);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Temperature Conversions");
        Console.ResetColor();
        Console.WriteLine($"{cel} = {fah}");
        Console.WriteLine();
    }
}
