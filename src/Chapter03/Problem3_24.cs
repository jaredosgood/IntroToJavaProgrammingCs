public static class Problem3_24
{
    public static void Main()
    {
        int rank = Random.Shared.Next(1, 14); // 1..13
        int suit = Random.Shared.Next(4);     // 0..3
        Console.WriteLine(Run(rank, suit));
    }

    public static string Run(int rank, int suit) =>
        $"The card you picked is {GetRank(rank)} of {GetSuit(suit)}";

    public static string GetRank(int rank) => rank switch
    {
        1 => "Ace",
        11 => "Jack",
        12 => "Queen",
        13 => "King",
        _ => rank.ToString()
    };

    public static string GetSuit(int suit) => suit switch
    {
        0 => "Clubs",
        1 => "Diamonds",
        2 => "Hearts",
        3 => "Spades",
        _ => "Error"
    };
}
