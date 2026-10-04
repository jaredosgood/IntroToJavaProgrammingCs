using System;

public static class Problem3_28
{
	public static void Main()
	{
        Console.Write("Enter r1's center x-, y-coordinates, width, and height: ");
        double[] r1 = ReadDoubles();

        Console.Write("Enter r2's center x-, y-coordinates, width, and height: ");
        double[] r2 = ReadDoubles();

        Console.WriteLine(Run(r1[0], r1[1], r1[2], r1[3], r2[0], r2[1], r2[2], r2[3]));
    }

    private static double[] ReadDoubles()
    {
        string line = Console.ReadLine() ?? "";
        string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        double[] numbers = new double[parts.Length];
        for (int i = 0; i < parts.Length; i++)
        {
            numbers[i] = double.Parse(parts[i], CultureInfo.InvariantCulture);
        }
        return numbers;
    }

    public static string Run(double r1CenterX, double r1CenterY, double r1Width, double r1Height,
                             double r2CenterX, double r2CenterY, double r2Width, double r2Height)
    {
        double r1Left = r1CenterX - r1Width / 2;
        double r1Right = r1CenterX + r1Width / 2;
        double r1Top = r1CenterY + r1Height / 2;
        double r1Bottom = r1CenterY - r1Height / 2;

        double r2Left = r2CenterX - r2Width / 2;
        double r2Right = r2CenterX + r2Width / 2;
        double r2Top = r2CenterY + r2Height / 2;
        double r2Bottom = r2CenterY - r2Height / 2;

        bool inside =
            r1Left <= r2Left
            && r1Right >= r2Right
            && r1Bottom <= r2Bottom
            && r1Top >= r2Top;

        boolean noOverlap = 
            r1Right < r2Left
            || r1Left > r2Right
            || r1Bottom > r2Top
            || r1Top < r2Bottom;

        return (inside, noOverlap) switch
        {
            (true, _) => "r2 is inside r1",
            (_, true) => "r2 does not overlap r1",
            _ => "r2 overlaps r1"
        };
    }
}
