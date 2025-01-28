using FluentAssertions;
using FluentAssertions.Execution;
using UnitConversion.ConversionEnums;

namespace UnitConversion.Tests;

public class LengthConverterTests
{
    [Fact]
    public void GivenAnInputInMetres_WhenTheOuputIsMetres_TheInputShouldMatchTheOutput()
    {
        // Arrange
        const double inputValue = 10;
        const double outputValue = 10;
        const LengthUnit inputUnit = LengthUnit.Metres;
        const LengthUnit outputUnit = LengthUnit.Metres;

        // Act
        var length = new Length(inputValue, inputUnit)
            .To(outputUnit);

        // Assert
        using (new AssertionScope())
        {
            length.Value.Should().Be(outputValue);
            length.Unit.Should().Be(outputUnit);
        }
    }

    [Fact]
    public void GivenAnInputInMetres_WhenTheOuputIsCentimetres_TheOutputValueShouldBeCorrect()
    {
        // Arrange
        const double inputValue = 10;
        const double outputValue = 1000;
        const LengthUnit inputUnit = LengthUnit.Metres;
        const LengthUnit outputUnit = LengthUnit.Centimetres;

        // Act
        var length = new Length(inputValue, inputUnit)
            .To(outputUnit);

        // Assert
        using (new AssertionScope())
        {
            length.Value.Should().Be(outputValue);
            length.Unit.Should().Be(outputUnit);
        }
    }
}