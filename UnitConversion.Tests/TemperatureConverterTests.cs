using FluentAssertions;
using FluentAssertions.Execution;
using UnitConversion.ConversionEnums;

namespace UnitConversion.Tests;

public class TemperatureConverterTests
{
    [Fact]
    public void GivenAnInputUnitCelsius_WhenTheOutputUnitCelsius_ThenTheValuesMatch()
    {
        // Arrange
        const double inputValue = 10;
        const double outputValue = 10;
        const TemperatureUnit inputUnit = TemperatureUnit.Celsius;
        const TemperatureUnit outputUnit = TemperatureUnit.Celsius;

        // Act
        var temp = new Temperature(inputValue, inputUnit)
            .To(outputUnit);

        // Assert
        using (new AssertionScope())
        {
            temp.Value.Should().Be(outputValue);
            temp.Unit.Should().Be(outputUnit);
        }
    }

    [Fact]
    public void GivenAnInputUnitCelsius_WhenTheOutputUnitFahrenheit_TheTheValueShouldBeCorrect()
    {
        // Arrange
        const double inputValue = 21;
        const double outputValue = 69.8;
        const TemperatureUnit inputUnit = TemperatureUnit.Celsius;
        const TemperatureUnit outputUnit = TemperatureUnit.Fahrenheit;

        // Act
        var temp = new Temperature(inputValue, inputUnit)
            .To(outputUnit);

        // Assert
        using (new AssertionScope())
        {
            temp.Value.Should().Be(outputValue);
            temp.Unit.Should().Be(outputUnit);
        }
    }

    [Fact]
    public void GivenAnInputUnitCelsius_WhenTheOutputUnitKelvin_ThenTheValueShouldBeCorrect()
    {
        // Arrange
        const double inputValue = 0;
        const double outputValue = 273.15;
        const TemperatureUnit inputUnit = TemperatureUnit.Celsius;
        const TemperatureUnit outputUnit = TemperatureUnit.Kelvin;

        // Act
        var temp = new Temperature(inputValue, inputUnit)
            .To(outputUnit);

        // Assert
        using (new AssertionScope())
        {
            temp.Value.Should().Be(outputValue);
            temp.Unit.Should().Be(outputUnit);
        }
    }

    [Fact]
    public void GivenAnInputUnitFahrenheit_WhenTheOutputUnitKelvin_ThenTheValueShouldBeCorrect()
    {
        // Arrange
        const double inputValue = 100;
        const double outputValue = 310.928;
        const TemperatureUnit inputUnit = TemperatureUnit.Fahrenheit;
        const TemperatureUnit outputUnit = TemperatureUnit.Kelvin;
        const double tolerance = 0.001;

        // Act
        var temp = new Temperature(inputValue, inputUnit)
            .To(outputUnit);

        // Assert
        using (new AssertionScope())
        {
            temp.Value.Should().BeApproximately(outputValue, tolerance);
            temp.Unit.Should().Be(outputUnit);
        }
    }

    [Fact]
    public void GivenAnInputUnitCelsius_WhenTheOutputUnitFahrenheitChaninedUnitKelvin_ThenTheValueShouldBeCorrect()
    {
        const double inputValue = 100;
        const double outputValue = 212;
        const TemperatureUnit inputUnit = TemperatureUnit.Celsius;
        const TemperatureUnit chainUnit = TemperatureUnit.Kelvin;
        const TemperatureUnit outputUnit = TemperatureUnit.Fahrenheit;

        // Act
        var temp = new Temperature(inputValue, inputUnit)
            .To(chainUnit)
            .To(outputUnit);

        // Assert
        using (new AssertionScope())
        {
            temp.Value.Should().Be(outputValue);
            temp.Unit.Should().Be(outputUnit);
        }
    }
}