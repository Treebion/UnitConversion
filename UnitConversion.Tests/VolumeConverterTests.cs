using FluentAssertions;
using FluentAssertions.Execution;
using UnitConversion.ConversionUnits;

namespace UnitConversion.Tests;

public class VolumeConverterTests
{
    [Fact]
    public void GivenInputUnitLitre_WhenOutputUnitLitre_ThenValueShouldMatch()
    {
        // Arrange
        const double inputValue = 1;
        const double outputValue = 1;
        const VolumeUnit inputUnit = VolumeUnit.Litre;
        const VolumeUnit outputUnit = VolumeUnit.Litre;

        // Act
        var volume = new Volume(inputValue, inputUnit)
            .To(outputUnit);

        // Assert
        using (new AssertionScope())
        {
            volume.Value.Should().Be(outputValue);
            volume.Unit.Should().Be(outputUnit);
        }
    }

    [Fact]
    public void GiveInputUnitLitre_WhenOutputUnitImperialPint_ThenValueShouldBeCorrect()
    {
        // Arrange
        const double inputValue = 12;
        const double outputValue = 21.117;
        const VolumeUnit inputUnit = VolumeUnit.Litre;
        const VolumeUnit outputUnit = VolumeUnit.ImperialPint;
        const double tolerance = 0.001;

        // Act
        var volume = new Volume(inputValue, inputUnit)
            .To(outputUnit);

        // Assert
        using (new AssertionScope())
        {
            volume.Value.Should().BeApproximately(outputValue, tolerance);
            volume.Unit.Should().Be(outputUnit);
        }
    }

    [Fact]
    public void GivenInputUnitLitre_WhenOutputUnitImperialPintChainedUnitUSLiquidGallon_ThenValueShouldBeCorrect()
    {
        // Arrange
        const double inputValue = 12;
        const double outputValue = 21.117;
        const VolumeUnit inputUnit = VolumeUnit.Litre;
        const VolumeUnit chainUnit = VolumeUnit.USLiquidGallon;
        const VolumeUnit outputUnit = VolumeUnit.ImperialPint;
        const double tolerance = 0.001;

        // Act
        var volume = new Volume(inputValue, inputUnit)
            .To(chainUnit)
            .To(outputUnit);

        // Assert
        using (new AssertionScope())
        {
            volume.Value.Should().BeApproximately(outputValue, tolerance);
            volume.Unit.Should().Be(outputUnit);
        }
    }
}
