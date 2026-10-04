namespace Chapter03
{
    public static class Problem3_26
    {
        public static void Main()
        {
            Console.Write("Enter an integer: ");
            int userInput = int.Parse(Console.ReadLine()!);
            Console.WriteLine(Run(userInput));
        }

        public static string Run(int userInput)
        {
            bool divBy4 = userInput % 4 == 0;
            bool divBy5 = userInput % 5 == 0;

            string line1 = $"Is {userInput} divisible by 4 and 5? {(divBy4 && divBy5)}\n";
            string line2 = $"Is {userInput} divisible by 4 or 5? {(divBy4 || divBy5)}\n";
            string line3 = $"Is {userInput} divisible by 4 or 5 but not both? {(divBy4 ^ divBy5)}";

            return line1 + line2 + line3;
        }
    }
}
