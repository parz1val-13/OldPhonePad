using System;

namespace OldPhonePad
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter input for OldPhonePad (end with #):");
            string input = Console.ReadLine();

            string output = PhonePad.Decode(input);
            Console.WriteLine($"Output: {output}");
        }
    }
}
