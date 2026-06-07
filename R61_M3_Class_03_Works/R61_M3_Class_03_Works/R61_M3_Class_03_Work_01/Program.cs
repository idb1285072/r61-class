using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_03_Work_01
{
    internal class Program
    {
        static string globalVar = "R61";
        static void Main()
        {
            Console.WriteLine("Variable & Data types");
            VariableAndDataTypes();
            Console.WriteLine();
            VariableScopes();
            Console.WriteLine("Arithmetic operators");
            AirithmeticOperators();
            Console.WriteLine();
            Console.WriteLine("Decisions");
            Decisions();
            Console.WriteLine();
            Console.WriteLine("Compound");
            CompundConditions();
            Console.WriteLine();
            Console.WriteLine("Loops");
            Loops();
            Console.WriteLine();
            Console.WriteLine("Short-circuit");
            ShortCircuiting();
            Console.WriteLine();
            PreVsPostIncrement();
            Console.WriteLine();
            ErrorHandling();
            Console.WriteLine();
            CheckedUnchecked();
            Console.WriteLine();
            MethodWithParameter("ESAD", 3); //Postional Call
            MethodWithParameter(n: 3, s: "C#"); //Named called
            MethodWithOptionalParameter("IDB-BISEW", 3);
            MethodWithOptionalParameter("IDB-BISEW");
            ExpressionBodiedMethod("Murad", "Hossain");
            Console.WriteLine();
            Console.WriteLine(MethodWithReturn("esad-cs"));
            Console.ReadLine();
        }//Main

        private static void ExpressionBodiedMethod(string v1, string v2)=> Console.WriteLine($"{v1} {v2}");
        private static void VariableScopes()
        {
            string localVar = "ESAD-CS";

            {
                int scopedVar = 14;

                {
                    Console.WriteLine(globalVar);
                    Console.WriteLine(localVar);
                    Console.WriteLine(scopedVar);
                    Console.WriteLine();
                }

            }
            Console.WriteLine(globalVar);
            Console.WriteLine(localVar);

        }

        private static string MethodWithReturn(string s)
        {
            return s.ToUpper();
        }

        private static void MethodWithParameter(string s, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{s}");
            }
            Console.WriteLine();
        }
        private static void MethodWithOptionalParameter(string s, int n=1)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{s}");
            }
            Console.WriteLine();
        }
        private static void CheckedUnchecked()
        {
            int n = int.MaxValue;
            Console.WriteLine("Unchecked");
            unchecked
            {
                n++;
            }
            Console.WriteLine(n);
            int m = int.MaxValue;
            Console.WriteLine("Checked");
            try
            {
                checked
                {
                    m++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

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
        private static void PreVsPostIncrement()
        {
            Console.WriteLine("Post increment");
            int a = 15;
            Console.WriteLine($"a={a++}");
           
            Console.WriteLine("Pre increment");
            int b = 15;
            Console.WriteLine($"b={++b}");
        }

        private static void AirithmeticOperators()
        {
            //Random r = new Random();
            //double n1 = Math.Floor(r.NextDouble()*(50-20)+20)+1,n2= Math.Floor(r.NextDouble() * (50 - 20) + 20) + 1;
            //double n1 = Math.PI / 4, n2 = .099;
            int n1 = 61, n2 = 14;
            Console.WriteLine($"{n1}+{n2}={n1+n2}");
            Console.WriteLine($"{n1}-{n2}={n1 - n2}");
            Console.WriteLine($"{n1}*{n2}={n1 * n2}");
            Console.WriteLine($"{n1}/{n2}={(double)n1 / n2}");
            Console.WriteLine($"{n1}%{n2}={n1 % n2}");

        }

        private static void VariableAndDataTypes()
        {
            int intVal=61;
            long longVal= 14L;
            float floatVal= 23.5F;
            double doubleVal = 33.33;
            decimal decimalVal = 45.99M;
            string stringVal = "ESAD";
            char charVal = 'E';
            bool boolVal = false;
            var implicitVal = "CS";
            DateTime dateVal = DateTime.Now;
            Console.WriteLine($"intVal={intVal}, longVal ={longVal}, floatVal ={floatVal:0.00}," +
                $"doubleVal={doubleVal},\ndecimalVal={decimalVal:C}, stringVal{stringVal}, charVal={charVal}" +
                $"boolVal={boolVal}, implicitVal={implicitVal}, dateTimeVal={dateVal:yyyy-MM-dd hh:mm tt}");
        }

        private static void ShortCircuiting()
        {
            int n = 10, m = 1;

            if (n >= 10 || ++m > 1)
            {
                Console.WriteLine(m);
            }
        }

        private static void Loops()
        {
            Console.WriteLine("while loop");
            int n = 1;
            while (n <= 10)
            {
                Console.Write($"{n}\t");
                n++;
            }
            Console.WriteLine();
            Console.WriteLine("for loop");
            for (int i = 1; i <= 10; i++)
            {
                Console.Write($"{i}\t");
            }
            Console.WriteLine();
            Console.WriteLine("do.. while loop");
            do
            {
                Console.Write($"{n}\t");
                n++;
            } while (n <= 10);
            Console.WriteLine();
        }

        private static void CompundConditions()
        {
            int x = 11, y = 22;
            if (x > 10 && y > 20)
            {
                Console.WriteLine("x>10 && y>20 = true");
            }
            else
            {
                Console.WriteLine("x>10 && y>20 = false");
            }
            if (x > 10 || x+y > 30)
            {
                Console.WriteLine("x>10 && x+y>30 = true");
            }
            else
            {
                Console.WriteLine("x>10 && x+y>30 = false");
            }
        }

        private static void Decisions()
        {
            Console.WriteLine("if-else");
            //Console.Write("Enter a number: ");
            //double n1 = double.Parse(Console.ReadLine());
            //Console.Write("Enter another number: ");
            //double n2 = double.Parse(Console.ReadLine());
            //Console.Write("Operation [+,-,*,/,%]: ");
            //string op = Console.ReadLine();
            //if(op =="+")
            //{
            //    Console.WriteLine($"{n1}+{n2}={n1+n2}");
            //}
            //else if (op == "-")
            //{
            //    Console.WriteLine($"{n1}-{n2}={n1 - n2}");
            //}
            //else if(op == "*")
            //{
            //    Console.WriteLine($"{n1}*{n2}={n1 * n2}");
            //}
            //else if (op == "/")
            //{
            //    Console.WriteLine($"{n1}/{n2}={n1 / n2}");
            //}
            //else if(op == "%")
            //{
            //    Console.WriteLine($"{n1}%{n2}={n1 % n2}");
            //}
            //else
            //{
            //    Console.WriteLine("Invalid operator");
            //}
            //Console.WriteLine("switch case");
            //switch (op)
            //{
            //    case "+":
            //        Console.WriteLine($"{n1}+{n2}={n1 + n2}");
            //        break;
            //    case "-":
            //        Console.WriteLine($"{n1}-{n2}={n1 - n2}");
            //        break;
            //    case "*":
            //        Console.WriteLine($"{n1}*{n2}={n1 * n2}");
            //        break;
            //    case "/":
            //        Console.WriteLine($"{n1}/{n2}={n1 / n2}");
            //        break;
            //    case "%":
            //        Console.WriteLine($"{n1}%{n2}={n1 % n2}");
            //        break;
            //    default:
            //        Console.WriteLine("Inalid operator");
            //        break;
            //}
            if(DateTime.Now.Hour >= 10)
            {
                Console.WriteLine("Good evening");
            }
            else 
            {
                Console.WriteLine("Good morning");
            }
            Console.WriteLine("switch case");
            switch (DateTime.Now.Hour>=12)
            {
                case true:
                    Console.WriteLine("Good evening");
                    break;
                case false:
                    Console.WriteLine("Good morning");
                    break;
                default:
                    Console.WriteLine("Good day");
                    break;
            }
        }
    }//Program
}
