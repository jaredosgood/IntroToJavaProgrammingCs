using System;
using Xunit;

public class Problem3_27Tests
{
    [Theory]
    [InlineData(100.5, 25.5, "The point is in the triangle")]
    [InlineData(100.5, 50.5, "The point is not in the triangle")]
    public void PrintsCorrectResults(double x, double y, string expectedOutput)
    {
        var actualOutput = Problem3_27.Run(x, y);

        Assert.Equal(expectedOutput, actualOutput);
    }
}
