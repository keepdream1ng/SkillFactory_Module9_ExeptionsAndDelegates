namespace Task2
{
    public class StringsSortApp
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("This application will sort the provided strings, or use a demo list to sort, if you didnt provide one any arguments.");
                if (args.Length == 0 )
                {
                    Console.WriteLine("Here is your hard coded demo list:");
                    args = new string[] { "Ivanov", "Petrov", "Sidorov", "Semenov", "Kuznetsov" };
                    Console.WriteLine(String.Join(Environment.NewLine, args));
                }

                var UserInput = new SortInputCommand(args);
                Console.WriteLine("Press 1 to sort alphabeticly or 2 to sort in reverse alphabetical order.");
                UserInput.GetInputAndSort();

                Console.WriteLine();
                Console.WriteLine("Here is your sorted list:");
                Console.WriteLine(String.Join(Environment.NewLine, args));  
            }
            catch (InvalidInputException e)
            {
                Console.WriteLine($" - this key you pressed is not 1 or 2. Error accured.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
    }

    public class SortInputCommand
    {
        public string[] ArrToSort;

        public delegate void NeedAlphSortEventHandler(ref string[] s);
        public event NeedAlphSortEventHandler NeedAlphSort;

        public delegate void NeedReverseAlphSortEventHandler(ref string[] s);
        public event NeedReverseAlphSortEventHandler NeedReverseAlphSort;

        private MyEventStringSorter _sorter;

        // It feels weird to put subscription in main, and i wanted to do it inside the class.
        // The consructor seems like a good plase for it, but I read somewhere what
        // putting business logic there is bad, maybe its the case for the bigger projects?
        public SortInputCommand(string[] arr)
        {
            ArrToSort = arr;
            _sorter = new MyEventStringSorter();
            NeedAlphSort += _sorter.SortInAlphabetical;
            NeedReverseAlphSort += _sorter.SortReverseAlphabetical;
        }
        public void GetInputAndSort()
        {
           switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    {
                        NeedAlphSort?.Invoke(ref ArrToSort); break;
                    }
                case ConsoleKey.D2:
                    {
                        NeedReverseAlphSort?.Invoke(ref ArrToSort); break;
                    }
                default:
                    {
                        throw new InvalidInputException();
                    }
            }
        }
    }


    public class MyEventStringSorter
    {
        public void SortInAlphabetical(ref string[] arr)
        {
            Array.Sort(arr);
        }

        public void SortReverseAlphabetical(ref string[] arr)
        {
            SortInAlphabetical(ref arr);
            Array.Reverse(arr);
        }
    }

    public class InvalidInputException : Exception
    {
        public InvalidInputException() : base() { }
    }
}