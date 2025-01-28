using System.Diagnostics.Metrics;
using UnitConversion.ConversionEnums;

namespace UnitConversion.DemoApp;

internal class Program
{
    static void Main(string[] args)
    {
        DemoLength();
        DemoSpeed();
        DemoTemperature();
        Chain();

        Console.ReadLine();
    }

    private static void Chain()
    {
        var miles = new Length(100, LengthUnit.Miles);
        var kilometres = miles
            .To(LengthUnit.Metres)
            .To(LengthUnit.Kilometres);
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
