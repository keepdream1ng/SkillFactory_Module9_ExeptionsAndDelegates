namespace Task1
{
    internal class BodyMassIndex
    {
        static void Main(string[] args)
        {
            double Weight;
            double Height;
            double BodyMassIndex;

            Console.WriteLine("Lets calculate your Body Mass Index!");
            try
            {
                Console.WriteLine("Enter your weight in kilograms.");
                Weight = GetDoubleFromInput();
                Console.WriteLine("Enter your height in meters.");
                Height = GetDoubleFromInput();

                BodyMassIndex = CalculateBMI(Weight, Height);

                Console.WriteLine($"Your Body Mass Index is {BodyMassIndex}");
            }
            catch(FormatException ex)
            {
                Console.WriteLine($"Your input probably wasnt a number, try using , instead of point. {ex.Message}");
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine($"You almost broke the program. {ex.Message}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Something went wrong: {ex.Message}");
                Console.WriteLine(ex.GetType());
            }
        }

        public static double GetDoubleFromInput()
        {
            double res = double.Parse(Console.ReadLine());
            if (res < 0)
            {
                throw new Exception("Required value cannot be negative!");
            }
            return res;
        }

        public static double CalculateBMI(double weight, double height)
        {
            if (height == 0)
            {
                throw new DivideByZeroException();
            }
            return (weight / (height * height));
        }
    }
}