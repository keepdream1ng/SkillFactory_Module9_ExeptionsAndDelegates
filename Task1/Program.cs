namespace Task1
{
    internal class ExceptionsLottery
    {
        static void Main(string[] args)
        {
            try
            {
                Exception[] exceptions = {new DivideByZeroException(), new FormatException(),
                    new OutOfMemoryException(), new StackOverflowException(), new WinningException("You Win!")};

                Console.WriteLine("Welcome to exceptions lottery, press any key to start!");
                Console.ReadKey();
                var Randomiser = new Random();  
                throw exceptions[Randomiser.Next(0, 6)];
                // Index out of range exception is an easter egg.
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine($"You were close. {ex.Message}");
            }
            catch(FormatException ex)
            {
                Console.WriteLine($"Try better next time. {ex.Message}");
            }
            catch(OutOfMemoryException ex)
            {
                Console.WriteLine($"You tried. {ex.Message}");
            }
            catch(StackOverflowException ex)
            {
                Console.WriteLine($"This one is cool, but not what you need. {ex.Message}");
            }
            catch(WinningException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Thanks for playing! Press any key to exit.");
                Console.ReadKey();
            }
        }

    }

    public class WinningException : Exception
    {
        public WinningException(string message) : base(message) { }
    }
}