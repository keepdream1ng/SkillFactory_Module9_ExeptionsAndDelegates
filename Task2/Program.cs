namespace Task2
{
    public class StringsSortByEventApp
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

                var SortCaller = new MySortEventPublisher();
                SortCaller.GetInputAndSort(args);

                Console.WriteLine();
                Console.WriteLine("Here is your sorted list:");
                Console.WriteLine(String.Join(Environment.NewLine, args));  
            }
            catch (InvalidInputException e)
            {
                Console.WriteLine($" - this key you pressed is not 1 or 2. Error occurred.");
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

    public class MySortEventPublisher
    {
        public delegate void NeedAlphSortEventHandler(string[] s);
        public event NeedAlphSortEventHandler NeedAlphSort;

        public delegate void NeedReverseAlphSortEventHandler(string[] s);
        public event NeedReverseAlphSortEventHandler NeedReverseAlphSort;

        private MyEventStringSortSubscriber _sorter;

        // It feels weird to put subscription in main, and i wanted to do it inside the class.
        // The consructor seems like a good plase for it, but I read somewhere what
        // putting business logic there is bad, maybe its the case for the bigger projects?
        public MySortEventPublisher()
        {
            _sorter = new MyEventStringSortSubscriber();
            NeedAlphSort += _sorter.SortInAlphabetical;
            NeedReverseAlphSort += _sorter.SortReverseAlphabetical;
        }
        public void GetInputAndSort(string[] arr)
        {
            Console.WriteLine("Press 1 to sort alphabeticly or 2 to sort in reverse alphabetical order.");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    {
                        NeedAlphSort?.Invoke(arr); break;
                    }
                case ConsoleKey.D2:
                    {
                        NeedReverseAlphSort?.Invoke(arr); break;
                    }
                default:
                    {
                        throw new InvalidInputException();
                    }
            }
        }
    }

    public class MyEventStringSortSubscriber
    {
        public void SortInAlphabetical(string[] arr)
        {
            Array.Sort(arr);
        }

        public void SortReverseAlphabetical(string[] arr)
        {
            SortInAlphabetical(arr);
            Array.Reverse(arr);
        }
    }

    public class InvalidInputException : Exception
    {
        public InvalidInputException() : base() { }
    }
}