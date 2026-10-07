using System;

public static class Problem3_31
{
	public static void Main(string[] args)
	{
		Console.Write("Enter the exchange rate from dollars to RMB: ");
		double exchangeRate = double.Parse(Console.ReadLine()!);
		if (exchangeRate <= 0)
		{
			Console.WriteLine("Error. The exchange rate must be greater than zero.");
			return;
		}

		Console.Write("Enter 0 to convert dollars to RMB and 1 vice versa: ");
		int conversionDirection = int.Parse(Console.ReadLine(!));

		if conversionDirection == 0)
		{
			Console.Write("Enter the dollar amount: ");
			double dollarAmount = double.Parse(Console.ReadLine()!);
			Console.WriteLine(Convert(exchangeRate, true, dollarAmount));

        }
		else if (conversionDirection == 1)
        {
			Console.Write("Enter the RMB amount: ");
			double rmbAmount = double.Parse(Console.ReadLine()!);
			Console.WriteLine(Convert(exchangeRate, false, rmbAmount));
        }
		else
		{
			Console.WriteLine("Error. Please enter 0 or 1.");
		}
    }

	public static string Convert(double exchangeRate, bool dollarToRmb, double amount)
	{
		if (dollarToRmb)
		{
			double rmbAmount = amount * exchangeRate;
			return $"${amount:F2} is {rmbAmount:F2} yuan";
        }

		double dollarAmount = amount / exchangeRate;
		return $"{amount:F2} yuan is ${dollarAmount:F2}";
    }
}
