using FluentAssertions;
using FluentAssertions.Execution;
using UnitConversion.ConversionUnits;
using Xunit;

namespace UnitConversion.Tests;

public class WeightConverterTests
{
    [Fact]
    public void GivenAnInputInKilograms_WhenTheOutputIsKilograms_TheInputShouldMatchTheOutput()
    {
        // Arrange
        const double inputValue = 10;
        const double outputValue = 10;
        const WeightUnit inputUnit = WeightUnit.Kilograms;
        const WeightUnit outputUnit = WeightUnit.Kilograms;

        // Act
        var weight = new Weight(inputValue, inputUnit).To(outputUnit);

        // Assert
        using (new AssertionScope())
        {
            weight.Value.Should().Be(outputValue);
            weight.Unit.Should().Be(outputUnit);
        }
    }

    [Fact]
    public void GivenAnInputInGrams_WhenTheOutputIsKilograms_TheOutputValueShouldBeCorrect()
    {
        // Arrange
        const double inputValue = 1000;
        const double outputValue = 1;
        const WeightUnit inputUnit = WeightUnit.Grams;
        const WeightUnit outputUnit = WeightUnit.Kilograms;

        // Act
        var weight = new Weight(inputValue, inputUnit).To(outputUnit);

        // Assert
        using (new AssertionScope())
        {
            weight.Value.Should().Be(outputValue);
            weight.Unit.Should().Be(outputUnit);
        }
    }

    [Fact]
    public void GivenAnInputInPounds_WhenTheOutputIsKilograms_TheOutputValueShouldBeCorrect()
    {
        // Arrange
        const double inputValue = 10;
        const double outputValue = 4.53592;
        const WeightUnit inputUnit = WeightUnit.Pounds;
        const WeightUnit outputUnit = WeightUnit.Kilograms;

        // Act
        var weight = new Weight(inputValue, inputUnit).To(outputUnit);

        // Assert
        using (new AssertionScope())
        {
            weight.Value.Should().BeApproximately(outputValue, 1e-5);
            weight.Unit.Should().Be(outputUnit);
        }
    }

    [Fact]
    public void ToString_ShouldReturnFormattedString()
    {
        // Arrange
        const double inputValue = 100;
        const WeightUnit inputUnit = WeightUnit.Kilograms;
        var weight = new Weight(inputValue, inputUnit);

        // Act
        var result = weight.ToString();

        // Assert
        result.Should().Be("100 Kilograms");
    }
}
