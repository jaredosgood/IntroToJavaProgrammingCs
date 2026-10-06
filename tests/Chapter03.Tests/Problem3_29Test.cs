using System;

public class Problem3_29Tests
{
    [Theory]
    [InlineData(0.5, 5.1, 13.0, 1.0, 1.7, 4.5, "circle2 is inside circle1")]
    [InlineData(3.4, 5.7, 5.5, 6.7, 3.5, 3.0, "circle2 overlaps circle1")]
    [InlineData(3.4, 5.5, 1.0, 5.5, 7.2, 1.0, "circle2 does not overlap circle1")]
    public void PrintsCorrectResults(
        double xC1, double yC1, double rC1,
        double xC2, double yC2, double rC2,
        string expectedOutput)
    {
        string actualOutput = Problem3_29.Run(xC1, yC1, rC1, xC2, yC2, rC2);

        Assert.Equal(expectedOutput, actualOutput);
    }
}
