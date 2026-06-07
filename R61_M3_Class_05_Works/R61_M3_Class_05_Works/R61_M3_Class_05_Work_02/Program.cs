using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_05_Work_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ErrorHandling();
            Console.ReadLine();

        }//Main

        private static void ErrorHandling()
        {
            int a = 10, b = 2;
            try
            {
                int c = a / b;
                int x = int.Parse("20a");
                throw new FileNotFoundException();
                throw new Exception("Unknown error");
            }
            catch (DivideByZeroException dex)
            {
                Console.WriteLine($"Math error: {dex.Message}");
            }
            catch (FormatException fex)
            {
                Console.WriteLine($"Parse error: {fex.Message}");
            }
            catch (FileNotFoundException fex)
            {
                Console.WriteLine($"404 error: {fex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Finally");
                
            }

            
        }
    }
}
