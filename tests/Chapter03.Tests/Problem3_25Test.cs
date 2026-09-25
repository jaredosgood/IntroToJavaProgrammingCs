public class Problem3_25Test
{
    [Theory]
    [InlineData(2.0, 2.0, 5.0, -1.0, 4.0, 2.0, -1.0, -2.0,
        "The intersecting point is at (2.88889, 1.11111)")]
    [InlineData(2.0, 2.0, 7.0, 6.0, 4.0, 2.0, -1.0, -2.0,
        "The two lines are parallel")]
    public void PrintsCorrectResults(
        double x1, double y1,
        double x2, double y2,
        double x3, double y3,
        double x4, double y4,
        string expectedOutput)
    {
        string actualOutput = Problem3_25.Run(x1, y1, x2, y2, x3, y3, x4, y4);

        Assert.Equal(expectedOutput, actualOutput);
    }
}