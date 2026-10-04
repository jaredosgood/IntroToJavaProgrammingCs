public static class Problem3_27
{
    public static void Main()
    {
        Console.Write("Enter a point's x- and y-coordinates: ");
        var values = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var x = double.Parse(values[0]);
        var y = double.Parse(values[1]);
        Console.WriteLine(Run(x, y));
    }

    public static string Run(double x, double y)
    {
        return x >= 0 && y >= 0 && y <= -0.5 * x + 100 ? "The point is in the triangle" : "The point is not in the triangle";
    }
}