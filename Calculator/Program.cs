using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("Välkommen till kalkylatorn :)");
                Console.WriteLine("Gör ett val i menyn för att utöra vald beräkning: ");
                Console.WriteLine();

                Console.WriteLine("[0] Avsluta");
                Console.WriteLine("[1] Addition (+)");
                Console.WriteLine("[2] Subtraktion (-)");
                Console.WriteLine("[3] Multiplikation (*)");
                Console.WriteLine("[4] Division (/)");
                Console.WriteLine("[5] Roten ur (Sqrt)");
                Console.WriteLine("[6] Upphöjt till (^)");
                Console.WriteLine("[7] Procent (%)");

                var menuCode = Console.ReadKey();
                string operation = "";

                switch (menuCode.Key)
                {
                    case ConsoleKey.D0:
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Kalkylatorn avslutas...");
                        running = false;
                        break;
                    case ConsoleKey.D1:
                        Console.WriteLine();
                        operation = "+";
                        EnterNumbers(operation);
                        ReadKey();
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine();
                        operation = "-";
                        EnterNumbers(operation);
                        ReadKey();
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine();
                        operation = "*";
                        EnterNumbers(operation);
                        ReadKey();
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine();
                        operation = "/";
                        EnterNumbers(operation);
                        ReadKey();
                        break;
                    case ConsoleKey.D5:
                        Console.WriteLine();
                        operation = "Sqrt";
                        EnterNumbers(operation);
                        ReadKey();
                        break;
                    case ConsoleKey.D6:
                        Console.WriteLine();
                        operation = "^";
                        EnterNumbers(operation);
                        ReadKey();
                        break;
                    case ConsoleKey.D7:
                        Console.WriteLine();
                        operation = "%";
                        EnterNumbers(operation);
                        ReadKey();
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Välj ett nummer som tillhör en kategori i menyn");
                        ReadKey();
                        break;
                }
            }
        }

        private static void ReadKey()
        {
            Console.WriteLine();
            Console.WriteLine("Tryck på valfri tangent för att återvända till menyn: ");
            Console.ReadKey();
            Console.Clear();
        }

        private static void EnterNumbers(string operation)
        {
            bool numbers = false;

            while (!numbers)
            {
                Console.WriteLine();

                string num1;
                string num2;

                if (operation == "Sqrt")
                {
                    Console.WriteLine($"Ange numret {operation}(_) och tryck enter: ");
                    num1 = Console.ReadLine();
                    num2 = "0";
                }
                else if (operation == "%") 
                {
                    Console.WriteLine($"Ange första numret _ {operation} av och tryck enter: ");
                    num1 = Console.ReadLine();
                    Console.WriteLine($"Ange andra numret {num1} {operation} av _ och tryck enter: ");
                    num2 = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine($"Ange första numret _ {operation} och tryck enter: ");
                    num1 = Console.ReadLine();
                    Console.WriteLine($"Ange andra numret {num1} {operation} _ och tryck enter: ");
                    num2 = Console.ReadLine();
                }
                
                if (true == decimal.TryParse(num1, out decimal result1) && true == decimal.TryParse(num2, out decimal result2))
                {
                    switch(operation)
                    {
                        case "+":
                            numbers = AddNumbers(num1, num2);
                            break;
                        case "-":
                            numbers = SubtractNumbers(num1, num2);
                            break;
                        case "*":
                            numbers = MultiplyNumbers(num1, num2);
                            break;
                        case "/":
                            numbers = DivideNumbers(num1, num2);
                            break;
                        case "Sqrt":
                            numbers = SquareRootOfNumber(num1);
                            break;
                        case "^":
                            numbers = PoweredToNumbers(num1, num2);
                            break;
                        case "%":
                            numbers = PercentOfNumbers(num1, num2);
                            break;
                        default:
                            Console.WriteLine("Ogiltig operation");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Felaktig inmatning");
                }
            }
        }

        private static bool AddNumbers(string num1, string num2)
        {
            decimal addend1 = Convert.ToDecimal(num1);
            decimal addend2 = Convert.ToDecimal(num2);
            Console.Write($"{addend1} + {addend2} = ");
            Console.WriteLine(addend1 + addend2);
            return true;
        }

        private static bool SubtractNumbers(string num1, string num2)
        {
            decimal minuend = Convert.ToDecimal(num1);
            decimal subtrahend = Convert.ToDecimal(num2);
            Console.Write($"{minuend} - {subtrahend} = ");
            Console.WriteLine(minuend - subtrahend);
            return true;
        }

        private static bool MultiplyNumbers(string num1, string num2)
        {
            decimal multiplicand = Convert.ToDecimal(num1);
            decimal multiplier = Convert.ToDecimal(num2);
            Console.Write($"{multiplicand} * {multiplier} = ");
            Console.WriteLine(multiplicand * multiplier);
            return true;
        }

        private static bool DivideNumbers(string num1, string num2)
        {
            decimal dividend = Convert.ToDecimal(num1);
            decimal divisor = Convert.ToDecimal(num2);

            if (divisor == 0)
            {
                Console.WriteLine("Det går inte att dividera med 0");
                return false;
            }
            else
            {
                Console.Write($"{dividend} / {divisor} = ");
                Console.WriteLine(dividend / divisor);
                return true;
            }
        }

        private static bool SquareRootOfNumber(string num1) 
        {
            double radicand = Convert.ToDouble(num1);
            Console.Write($"Sqrt({radicand}) = ");
            Console.WriteLine(Math.Sqrt(radicand));
            return true;
        }

        private static bool PoweredToNumbers(string num1, string num2) 
        {
            double baseNumber = Convert.ToDouble(num1);
            double exponent = Convert.ToDouble(num2);
            Console.Write($"{baseNumber}^{exponent} = ");
            Console.WriteLine(Math.Pow(baseNumber, exponent));
            return true;
        }

        private static bool PercentOfNumbers(string num1, string num2) 
        {
            decimal percent = Convert.ToDecimal(num1);
            decimal whole = Convert.ToDecimal(num2);
            decimal calculatedValue = (whole / 100) * percent;
            Console.Write($"{percent} % av {whole} = ");
            Console.WriteLine(calculatedValue);
            return true;
        }
    }
}
