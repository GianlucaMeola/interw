using System;

namespace BynaryToInt
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Digit a binary string to convert:");
                string input = Console.ReadLine();
                string output = BinaryConverter.ConvertBinary(input);
                Console.WriteLine($"The interger value of {input} is: {output}");
            } while (true);
        }
    }
}
