using System;

public class Problem3_29
{
	public static void Main()
	{
		Console.Write("Enter circle1's center x-, y-coordinates, and radius: ");
		var (xC1, yC1, rC1) = ReadCircle();

		Console.Write("Enter circle2's center x-, y-coordinates, and radius: ");
        var (xC2, yC2, rC2) = ReadCircle();

		Console.WriteLine(Run(xC1, yC1, rC1, xC2, yC2, rC2));
    }

	public static string Run(double xC1, double yC1, double rC1, double xC2, double yC2, double rC2)
    {
        double distance = Math.Sqrt(Math.Pow(xC2 - xC1, 2) + Math.Pow(yC2 - yC1, 2));
		return distance switch
		{
			_ when distance <= rC1 - rC2 => "circle2 is inside circle1",
			_ when distance <= rC1 + rC2 => "circle2 overlaps circle1",
			_ => "circle2 does not overlap circle1"
		};
    }

	public static (double X, double Y, double R) ReadCircle()
    {
		double[] values = [.. (Console.ReadLine() ?? "")
			.Split(' ', StringSplitOptions.RemoveEmptyEntries)
			.Select(static=> double.Parse(static, CultureInfo.InvariantCulture))];

        return (values[0], values[1], values[2]);
    }
}
