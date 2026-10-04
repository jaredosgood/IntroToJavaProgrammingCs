using System.Globalization;

public static class Problem3_25
{
    public static void Main()
    {
        Console.Write("Enter x1, y1, x2, y2, x3, y3, x4, y4: ");
        // This reads one line of input and turns it into an array of doubles
        double[] v = [.. Console.ReadLine()!
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(s => double.Parse(s, CultureInfo.InvariantCulture))];
        Console.WriteLine(Run(v[0], v[1], v[2], v[3], v[4], v[5], v[6], v[7]));
    }

    public static string Run(double x1, double y1,
                             double x2, double y2,
                             double x3, double y3,
                             double x4, double y4)
    {
        double a = y1 - y2;
        double b = -(x1 - x2);
        double e = (y1 - y2) * x1 - (x1 - x2) * y1;

        double c = y3 - y4;
        double d = -(x3 - x4);
        double f = (y3 - y4) * x3 - (x3 - x4) * y3;

        double denominator = a * d - b * c;
        if (denominator == 0)
        {
            return "The two lines are parallel";
        }

        double x = (e * d - b * f) / denominator;
        double y = (a * f - e * c) / denominator;

        // This builds the result string with both numbers formatted to five decimal places,
        // independent of the machine's locale.
        return string.Create(CultureInfo.InvariantCulture,
            $"The intersecting point is at ({x:F5}, {y:F5})");
    }
}