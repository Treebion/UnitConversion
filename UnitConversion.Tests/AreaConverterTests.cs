using FluentAssertions;
using FluentAssertions.Execution;
using UnitConversion.ConversionUnits;

namespace UnitConversion.Tests;

public class AreaConverterTests
{
    [Fact]
    public void GivenAnInputInSquareMetres_WhenTheOutputIsSquareMetres_TheInputShouldMatchTheOutput()
    {
        // Arrange
        const double inputValue = 10;
        const double outputValue = 10;
        const AreaUnit inputUnit = AreaUnit.SquareMetres;
        const AreaUnit outputUnit = AreaUnit.SquareMetres;

        // Act
        var area = new Area(inputValue, inputUnit).To(outputUnit);

        // Assert
        using (new AssertionScope())
        {
            area.Value.Should().Be(outputValue);
            area.Unit.Should().Be(outputUnit);
        }
    }

    [Fact]
    public void GivenAnInputInSquareMetres_WhenTheOutputIsSquareKilometres_TheOutputValueShouldBeCorrect()
    {
        // Arrange
        const double inputValue = 1_000_000;
        const double outputValue = 1;
        const AreaUnit inputUnit = AreaUnit.SquareMetres;
        const AreaUnit outputUnit = AreaUnit.SquareKilometres;

        // Act
        var area = new Area(inputValue, inputUnit).To(outputUnit);

        // Assert
        using (new AssertionScope())
        {
            area.Value.Should().Be(outputValue);
            area.Unit.Should().Be(outputUnit);
        }
    }

    [Fact]
    public void GivenAnInputInSquareFeet_WhenTheOutputIsSquareMetres_TheOutputValueShouldBeCorrect()
    {
        // Arrange
        const double inputValue = 10;
        const double outputValue = 0.92903;
        const AreaUnit inputUnit = AreaUnit.SquareFeet;
        const AreaUnit outputUnit = AreaUnit.SquareMetres;

        // Act
        var area = new Area(inputValue, inputUnit).To(outputUnit);

        // Assert
        using (new AssertionScope())
        {
            area.Value.Should().BeApproximately(outputValue, 1e-5);
            area.Unit.Should().Be(outputUnit);
        }
    }

    [Fact]
    public void ToString_ShouldReturnFormattedString()
    {
        // Arrange
        const double inputValue = 100;
        const AreaUnit inputUnit = AreaUnit.SquareMetres;
        var area = new Area(inputValue, inputUnit);

        // Act
        var result = area.ToString();

        // Assert
        result.Should().Be("100 SquareMetres");
    }
}
