using System.Runtime.CompilerServices;

namespace Task2
{
    public delegate void SortAlph(ref string[] s);
    public delegate void SortRevAlph(ref string[] s);

    public class StringsSortApp
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("This application will sort the provided strings, or use a demo list to sort, if you didnt provide one any arguments.");
            if (args.Length == 0 )
            {
                Console.WriteLine("Here is your hard coded demo list:");
                args = new string[] { "Ivanov", "Petrov", "Sidorov", "Semenov", "Kuznetsov" };
                Console.WriteLine(String.Join(Environment.NewLine, args));
            }

            var UserInput = new SortInputCommand(args);
            Console.WriteLine("Input 1 to sort alphabeticly or 2 to sort in reverse alphabetical order.");
            UserInput.GetInputAndSort();

            Console.WriteLine("Here is your sorted list:");
            Console.WriteLine(String.Join(Environment.NewLine, args));  
        }
    }

    public class SortInputCommand
    {
        private string[] _arr;
        MyEventStringSorter sorter;

        public event SortAlph NeedAlphSort;
        public event SortRevAlph NeedReverseAlphSort;

        public SortInputCommand(string[] arr)
        {
            _arr = arr;
            sorter = new MyEventStringSorter();
            NeedAlphSort += MyEventStringSorter.SortInAlphabetical;
            NeedReverseAlphSort += MyEventStringSorter.SortReverseAlphabetical;
        }
        public void GetInputAndSort()
        {
           switch (Console.ReadLine())
            {
                case "1":
                    {
                        NeedAlphSort?.Invoke(ref _arr); break;
                    }
                case "2":
                    {
                        NeedReverseAlphSort?.Invoke(ref _arr); break;
                    }
                default:
                    {
                        throw new FormatException();
                    }
            }
        }
    }


    public class MyEventStringSorter
    {
        public static void SortInAlphabetical(ref string[] arr)
        {
            Array.Sort(arr);
        }

        public static void SortReverseAlphabetical(ref string[] arr)
        {
            SortInAlphabetical(ref arr);
            Array.Reverse(arr);
        }
    }

    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message) { }
    }
}