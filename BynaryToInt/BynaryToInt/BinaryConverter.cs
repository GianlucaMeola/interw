using System;
using System.Numerics;

namespace BynaryToInt
{
    public static class BinaryConverter
    {
        public static string ConvertBinary(string strBinary)
        {
            do
            {
                if (!isBinary(strBinary))
                {
                    Console.WriteLine($"Error: '{strBinary}' is not a binary.");
                    Console.WriteLine("Digit a binary string to convert:");
                    strBinary = Console.ReadLine();
                }

            } while (!isBinary(strBinary));

            return binaryToInt(strBinary).ToString();
        }

        static bool isBinary(string s)
        {
            bool result = false;
            foreach (char c in s)
            {
                if (c != '0' && c != '1')
                    return result = false;
                result = true;
            }
            return result;
        }

        static BigInteger binaryToInt(string s)
        {
            BigInteger tot = 0;
            int lngBinary = s.Length;

            foreach (char c in s)
            {
                lngBinary = lngBinary - 1;
                tot = tot + ((BigInteger)Char.GetNumericValue(c) * (BigInteger)(Math.Pow(2, lngBinary)));
            }
            return tot;
        }
    }
}
