using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace UnitConversion.DemoApp;

public static class UnitConverterHelper
{
    public static void Run()
    {
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Unit Conversion Tool");
            Console.ResetColor();

            // 1. Select Unit Type
            Type selectedConverterType = SelectConverterType();
            if (selectedConverterType == null) return;

            // 2. Select Units
            Type enumType = selectedConverterType.GetInterfaces()
                .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IUnitConverter<,>))
                .GetGenericArguments()[0];

            object fromUnit = SelectUnit(enumType, "Convert from");
            object toUnit = SelectUnit(enumType, "Convert to");

            // 3. Enter Value
            double value = GetConversionValue();

            // 4. Perform Conversion
            PerformConversion(selectedConverterType, fromUnit, toUnit, value);

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    private static Type SelectConverterType()
    {
        // Ensure all referenced assemblies are loaded
        LoadReferencedAssemblies();

        // Get all unit conversion types across all loaded assemblies
        var converterTypes = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IUnitConverter<,>)))
            .ToList();

        // Debugging: Show a warning if no converters are found
        if (!converterTypes.Any())
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n❌ No unit converters found! Ensure your conversion classes implement IUnitConverter<T, TSelf>.");
            Console.WriteLine("Press any key to exit.");
            Console.ResetColor();
            Console.ReadKey();
            return null;
        }

        // Display options
        Console.WriteLine("\nSelect a unit type:");
        for (int i = 0; i < converterTypes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {converterTypes[i].Name}");
        }
        Console.Write("\nEnter choice (or 0 to exit): ");

        // Get user input
        int choice = GetUserChoice(converterTypes.Count);
        return choice == 0 ? null : converterTypes[choice - 1];
    }

    private static void LoadReferencedAssemblies()
    {
        var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
        var referencedAssemblies = loadedAssemblies
            .SelectMany(a => a.GetReferencedAssemblies())
            .Where(a => !loadedAssemblies.Any(la => la.FullName == a.FullName)) // Only load if not already loaded
            .Distinct();

        foreach (var assemblyName in referencedAssemblies)
        {
            try
            {
                AppDomain.CurrentDomain.Load(assemblyName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Warning: Could not load assembly {assemblyName.Name}: {ex.Message}");
            }
        }
    }

    private static object SelectUnit(Type enumType, string prompt)
    {
        var units = Enum.GetValues(enumType).Cast<object>().ToList();

        Console.WriteLine($"\n{prompt}:");
        for (int i = 0; i < units.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {units[i]}");
        }
        Console.Write("\nEnter choice: ");

        int choice = GetUserChoice(units.Count);
        return units[choice - 1];
    }

    private static double GetConversionValue()
    {
        double value;
        Console.Write("\nEnter value to convert: ");
        while (!double.TryParse(Console.ReadLine(), out value))
        {
            Console.Write("Invalid input. Enter a valid number: ");
        }
        return value;
    }

    private static void PerformConversion(Type converterType, object fromUnit, object toUnit, double value)
    {
        // Find constructor (double value, Enum unit)
        var constructor = converterType.GetConstructor(new[] { typeof(double), fromUnit.GetType() });
        if (constructor == null)
        {
            Console.WriteLine("❌ Error: No valid constructor found.");
            return;
        }

        // Instantiate converter
        var converterInstance = constructor.Invoke(new object[] { value, fromUnit });

        // Invoke the 'To' method dynamically
        var toMethod = converterType.GetMethod("To", new[] { fromUnit.GetType() });
        if (toMethod == null)
        {
            Console.WriteLine("❌ Error: No valid To() method found.");
            return;
        }

        var result = toMethod.Invoke(converterInstance, new[] { toUnit });

        // Get value and unit properties
        var valueProp = converterType.GetProperty("Value");
        var unitProp = converterType.GetProperty("Unit");

        double convertedValue = (double)valueProp.GetValue(result);
        object convertedUnit = unitProp.GetValue(result);

        // Display result with original and converted values
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nOriginal: {value} {fromUnit}");
        Console.WriteLine($"Converted: {convertedValue} {convertedUnit}");
        Console.ResetColor();
    }

    private static int GetUserChoice(int maxChoice)
    {
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > maxChoice)
        {
            Console.Write("Invalid choice. Try again: ");
        }
        return choice;
    }
}
