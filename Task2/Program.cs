namespace Task2
{
    internal class StringsSortApp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This application will sort the provided strings, or use a demo list to sort, if you didnt one any arguments.");
            if (args.Length == 0 )
            {
                args = new string[] { "Ivanov", "Petrov", "Sidorov", "Semenov", "Kuznetsov" };
                Console.WriteLine("Here is your demo list:");
                Console.WriteLine(String.Join(Environment.NewLine, args));  
            }
        }


    }

    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message) { }
    }
}