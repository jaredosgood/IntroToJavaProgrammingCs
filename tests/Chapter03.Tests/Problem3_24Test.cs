public class Problem3_24Test
{
    public static TheoryData<int, int, string> Data => new()
    {
        { 1, 0, "The card you picked is Ace of Clubs" },
        { 4, 1, "The card you picked is 4 of Diamonds" },
        { 6, 2, "The card you picked is 6 of Hearts" },
        { 8, 3, "The card you picked is 8 of Spades" },
        { 13, 3, "The card you picked is King of Spades" },
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void PrintsCorrectResults(int rank, int suit, string expectedOutput)
    {
        string actualOutput = Problem3_24.Run(rank, suit);

        Assert.Equal(expectedOutput, actualOutput);
    }
}