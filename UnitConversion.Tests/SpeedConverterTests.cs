using FluentAssertions;
using FluentAssertions.Execution;
using UnitConversion.ConversionEnums;

namespace UnitConversion.Tests;

public class SpeedConverterTests
{
    [Fact]
    public void GivenInputUnitMilesPerHour_WhenOutputUnitMilesPerHour_ThenValuesShouldMatch()
    {
        // Arrange
        const double inputValue = 10;
        const double outputValue = 10;
        const SpeedUnit inputUnit = SpeedUnit.MilesPerHour;
        const SpeedUnit outputUnit = SpeedUnit.MilesPerHour;

        // Act
        var speed = new Speed(inputValue, inputUnit)
            .To(SpeedUnit.MilesPerHour);

        // Assert
        using (new AssertionScope())
        {
            speed.Value.Should().Be(outputValue);
            speed.Unit.Should().Be(outputUnit);
        }
    }

    [Fact]
    public void GivenInputUnitMilesPerHour_WhenOutputUnitKilometresPerHour_ThenValueShouldBeCorrect()
    {
        // Arrange
        const double inputValue = 10;
        const double outputValue = 16.0934;
        const SpeedUnit inputUnit = SpeedUnit.MilesPerHour;
        const SpeedUnit outputUnit = SpeedUnit.KilometresPerHour;
        const double tolerance = 0.001;

        // Act
        var speed = new Speed(inputValue, inputUnit)
            .To(outputUnit);

        // Arrange
        using (new AssertionScope())
        {
            speed.Value.Should().BeApproximately(outputValue, tolerance);
            speed.Unit.Should().Be(outputUnit);
        }
    }
}
