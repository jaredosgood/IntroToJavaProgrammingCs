namespace Chapter03.Tests;

public class Problem3_26Test
{
    public static TheoryData<int, string> Data => new()
    {
        {
            10,
            """
            Is 10 divisible by 4 and 5? False
            Is 10 divisible by 4 or 5? True
            Is 10 divisible by 4 or 5 but not both? True
            """
        },
        {
            40,
            """
            Is 40 divisible by 4 and 5? True
            Is 40 divisible by 4 or 5? True
            Is 40 divisible by 4 or 5 but not both? False
            """
        },
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void PrintsCorrectResults(int userInput, string expectedOutput)
    {
        string actualOutput = Problem3_26.Run(userInput);

        // C# raw string literals keep the source file's line endings (possibly \r\n),
        // unlike Java text blocks, which use \n.
        Assert.Equal(expectedOutput.ReplaceLineEndings("\n"), actualOutput);
    }
}
