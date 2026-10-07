using System;
using System.Globalization;
using Xunit;

[CollectionDefinition(nameof(ConsoleCollection), DisableParallelization = true)]
public sealed class ConsoleCollection;

[Collection(nameof(ConsoleCollection))]
public sealed class Problem3_31Test : IDisposable
{
    private const string RatePrompt = "Enter the exchange rate from dollars to RMB: ";
    private const string DirectionPrompt = "Enter 0 to convert dollars to RMB and 1 vice versa: ";

    private readonly TextReader _originalIn = Console.In;
    private readonly TextWriter _originalOut = Console.Out;
    private readonly CultureInfo _originalCulture = CultureInfo.CurrentCulture;
    private readonly StringWriter _capturedOutput = new();

    public Problem3_31Test()
    {
        // Ensure decimal input and output use a period
        CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
        Console.SetOut(_capturedOutput);
    }

    // Dispose runs after every test, so it is @AfterEach
    public void Dispose()
    {
        Console.SetIn(_originalIn);
        Console.SetOut(_originalOut);
        CultureInfo.CurrentCulture = _originalCulture;

        _capturedOutput.Dispose();
    }

    [Theory]
    // Dollars to yuan
    [InlineData(6.5, true, 100.0, "$100.00 is 650.00 yuan")]
    [InlineData(6.5, true, 0.0, "$0.00 is 0.00 yuan")]
    [InlineData(1.0, true, 25.50, "$25.50 is 25.50 yuan")]
    [InlineData(0.5, true, 10.0, "$10.00 is 5.00 yuan")]
    // Yuan to dollars
    [InlineData(6.5, false, 650.0, "650.00 yuan is $100.00")]
    [InlineData(6.5, false, 0.0, "0.00 yuan is $0.00")]
    [InlineData(1.0, false, 25.50, "25.50 yuan is $25.50")]
    [InlineData(0.5, false, 10.0, "10.00 yuan is $20.00")]
    // Results requiring rounding to two decimal places
    [InlineData(6.5, true, 10.25, "$10.25 is 66.63 yuan")]
    [InlineData(6.5, false, 100.0, "100.00 yuan is $15.38")]
    public void ConvertsAmountCorrectly(
        double exchangeRate,
        bool dollarToRmb,
        double amount,
        string expectedOutput)
    {
        string actualOutput = Problem3_31.Convert(exchangeRate, dollarToRmb, amount);

        Assert.Equal(expectedOutput, actualOutput);
    }

    [Theory]
    [MemberData(nameof(ConsoleCases))]
    public void HandlesConsoleInputCorrectly(string input, string expectedOutput)
    {
        Console.SetIn(new StringReader(input));

        Problem3_31.Main([]);

        Assert.Equal(expectedOutput + Environment.NewLine, _capturedOutput.ToString());
    }

    public static TheoryData<string, string> ConsoleCases => new()
    {
        // Valid dollar-to-yuan conversion
        { "6.5\n0\n100\n", RatePrompt + DirectionPrompt + "Enter the dollar amount: " + "$100.00 is 650.00 yuan" },

        // Valid yuan-to-dollar conversion
        { "6.5\n1\n650\n", RatePrompt + DirectionPrompt + "Enter the RMB amount: " + "650.00 yuan is $100.00" },

        // Zero exchange rate
        { "0\n", RatePrompt + "Error. The exchange rate must be greater than zero." },

        // Negative exchange rate
        { "-6.5\n", RatePrompt + "Error. The exchange rate must be greater than zero." },

        // Invalid conversion directions.
        { "6.5\n2\n", RatePrompt + DirectionPrompt + "Error. Please enter 0 or 1." },
        { "6.5\n-1\n", RatePrompt + DirectionPrompt + "Error. Please enter 0 or 1." },
    };
}
