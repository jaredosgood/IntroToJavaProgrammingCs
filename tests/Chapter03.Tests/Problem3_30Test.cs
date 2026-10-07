using System.Globalization;
using Xunit;

public class Problem3_30Test
{
    [Theory]
    [InlineData(0, "2026-01-01T00:00:00Z", "The current time is 12:00:00 AM")]
    [InlineData(0, "2026-01-01T00:59:59Z", "The current time is 12:59:59 AM")]
    [InlineData(0, "2026-01-01T05:07:09Z", "The current time is 5:07:09 AM")]
    [InlineData(0, "2026-01-01T11:59:59Z", "The current time is 11:59:59 AM")]
    [InlineData(0, "2026-01-01T12:00:00Z", "The current time is 12:00:00 PM")]
    [InlineData(0, "2026-01-01T12:59:59Z", "The current time is 12:59:59 PM")]
    [InlineData(0, "2026-01-01T13:07:09Z", "The current time is 1:07:09 PM")]
    [InlineData(0, "2026-01-01T23:59:59Z", "The current time is 11:59:59 PM")]
    [InlineData(3, "2026-01-01T23:15:45Z", "The current time is 2:15:45 AM")]
    [InlineData(-5, "2026-01-01T02:15:45Z", "The current time is 9:15:45 PM")]
    [InlineData(2, "2026-01-01T10:00:00Z", "The current time is 12:00:00 PM")]
    [InlineData(-2, "2026-01-01T02:00:00Z", "The current time is 12:00:00 AM")]
    public void ReturnsCorrectLocalTime(int timeZoneOffset, string utcTime, string expectedOutput)
    {
        long totalMillis = DateTimeOffset
            .Parse(utcTime, CultureInfo.InvariantCulture)
            .ToUnixTimeMilliseconds();

        string actualOutput = Problem3_30.Run(timeZoneOffset, totalMillis);

        Assert.Equal(expectedOutput, actualOutput);
    }
}