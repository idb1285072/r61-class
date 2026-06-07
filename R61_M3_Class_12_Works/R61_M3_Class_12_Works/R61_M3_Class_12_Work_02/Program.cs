using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_12_Work_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 0b_000000_00000000_000000000_00111101;
            int m = 0b0_000000_00000000_000000000_00111011;
            Console.WriteLine($"Decimal {n}");
            Console.WriteLine($"Binary {Convert.ToString(n, 2)}");
            Console.WriteLine($"Octal {Convert.ToString(n, 8)}");
            Console.WriteLine($"HexaDecimal {Convert.ToString(n, 16)}");
            Console.WriteLine();
            Console.WriteLine($"Decimal {m}");
            Console.WriteLine($"Binary {Convert.ToString(m, 2)}");
            Console.WriteLine($"Octal {Convert.ToString(m, 8)}");
            Console.WriteLine($"HexaDecimal {Convert.ToString(m, 16)}");
            //////
            Console.WriteLine("~n");
            Console.WriteLine($"Decimal {Convert.ToString(~n, 10)}");
            Console.WriteLine($"Binary {Convert.ToString(~n, 2)}");
            Console.WriteLine($"Octal {Convert.ToString(~n, 8)}");
            Console.WriteLine($"HexaDecimal {Convert.ToString(~n, 16)}");
            Console.WriteLine("m & n");
            Console.WriteLine($"Decimal {Convert.ToString(m&n, 10)}");
            Console.WriteLine($"Binary {Convert.ToString(m&n, 2)}");
            Console.WriteLine($"Octal {Convert.ToString(m&n, 8)}");
            Console.WriteLine($"HexaDecimal {Convert.ToString(m&n, 16)}");
            Console.WriteLine("m | n");
            Console.WriteLine($"Decimal {Convert.ToString(m | n, 10)}");
            Console.WriteLine($"Binary {Convert.ToString(m | n, 2)}");
            Console.WriteLine($"Octal {Convert.ToString(m | n, 8)}");
            Console.WriteLine($"HexaDecimal {Convert.ToString(m | n, 16)}");
            Console.WriteLine("m ^ n");
            Console.WriteLine($"Decimal {Convert.ToString(m ^ n, 10)}");
            Console.WriteLine($"Binary {Convert.ToString(m ^ n, 2)}");
            Console.WriteLine($"Octal {Convert.ToString(m ^ n, 8)}");
            Console.WriteLine($"HexaDecimal {Convert.ToString(m ^ n, 16)}");
            Console.WriteLine("n << 2");
            Console.WriteLine($"Decimal {Convert.ToString(n<<2, 10)}");
            Console.WriteLine($"Binary {Convert.ToString(n << 2, 2)}");
            Console.WriteLine($"Octal {Convert.ToString(n << 2, 8)}");
            Console.WriteLine($"HexaDecimal {Convert.ToString(n << 2, 16)}");
            Console.WriteLine("n >> 2");
            Console.WriteLine($"Decimal {Convert.ToString(n >> 2, 10)}");
            Console.WriteLine($"Binary {Convert.ToString(n >> 2, 2)}");
            Console.WriteLine($"Octal {Convert.ToString(n >>2, 8)}");
            Console.WriteLine($"Hexa Decimal {Convert.ToString(n >> 2, 16)}");
            Console.ReadLine();
        }
    }
}
