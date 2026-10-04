using System;
using Xunit;

public class Problem3_28Test
{
    [Theory]
    [InlineData(2.5, 4d, 2.5, 43d, 1.5, 5d, 0.5, 3d, "r2 is inside r1")]
    [InlineData(1d, 2d, 3d, 5.5, 3d, 4d, 4.5, 5d, "r2 overlaps r1")]
    [InlineData(1d, 2d, 3d, 3d, 40d, 45d, 3d, 2d, "r2 does not overlap r1")]
    public void PrintsCorrectResults(
        double r1CenterX, double r1CenterY, double r1Width, double r1Height,
        double r2CenterX, double r2CenterY, double r2Width, double r2Height,
        string expectedOutput)
    {
        string actualOutput = Problem3_28.Run(r1CenterX, r1CenterY, r1Width, r1Height,
                                              r2CenterX, r2CenterY, r2Width, r2Height);

        Assert.Equal(expectedOutput, actualOutput);
    }
}
