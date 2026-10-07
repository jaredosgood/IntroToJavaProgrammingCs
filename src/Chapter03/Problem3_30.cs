using System;

public static class Problem3_30
{
	public static void Main()
	{
		Console.Write("Enter the time zone offset to GMT: ");
		int timeZoneOffset = int.Parse(Console.ReadLine());

		Console.WriteLine(Run(timeZoneOffset));
    }

	public static string Run(int timeZoneOffset, long totalMillis)
	{
		long totalSec = totalMillis / 1000;
		long currSec = totalSec % 60;

        long totalMin = totalSec / 60;
        long currMin = totalMin % 60;

        long totalHr = totalMin / 60;
        long currHr = totalHr % 24;

        long currHrLocal = ((currHr + timeZoneOffset) % 24 + 24) % 24;

        string period = currHrLocal < 12 ? "AM" : "PM";

        long hour12 = currHrLocal % 12;
        if (hour12 == 0)
        {
            hour12 = 12;
        }

        return $"The current time is {hour12}:{currMin:D2}:{currSec:D2} {period}";
    }
}
