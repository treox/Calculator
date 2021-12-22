using System;
using System.Linq;
using System.Text;

namespace Calculator
{
    public class Program
    {
        private static decimal[] numbersArray = { };
        private static StringBuilder sbNumbers = new StringBuilder();

        static void Main(string[] args)
        {
            bool running = true;
            decimal num1 = 0;
            decimal num2 = 0;
            
            while (running)
            {
                Console.WriteLine("Välkommen till kalkylatorn :)");
                Console.WriteLine("Gör ett val i menyn för att utöra vald beräkning: ");
                Console.WriteLine();

                Console.WriteLine("[0] Avsluta");
                Console.WriteLine("[1] Addition (+)");
                Console.WriteLine("[2] Addition med flera nummer(+ + + ...)");
                Console.WriteLine("[3] Subtraktion (-)");
                Console.WriteLine("[4] Subtraktion med flera nummer(- - - ...)");
                Console.WriteLine("[5] Multiplikation (*)");
                Console.WriteLine("[6] Division (/)");
                Console.WriteLine("[7] Roten ur (Sqrt)");
                Console.WriteLine("[8] Upphöjt till (^)");
                Console.WriteLine("[9] Procent (%)");

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

                        Console.WriteLine($"Ange första numret _ {operation} och tryck enter: ");
                        num1 = ReadNumber();
                        Console.WriteLine($"Ange andra numret {num1} {operation} _ och tryck enter: ");
                        num2 = ReadNumber();

                        decimal receivedSum = AddNumbers(num1, num2, numbersArray);
                        Console.Write($"{num1} + {num2} = ");
                        Console.WriteLine(receivedSum);
                        ReadKey();
                        break;

                    case ConsoleKey.D2:
                        Console.WriteLine();
                        operation = "+ + + ...";

                        bool isNotCorrectAdditionFormat = true;
                        string receivedLineAddition = "";

                        while (isNotCorrectAdditionFormat)
                        {
                            Console.WriteLine($"Ange nummer som ska adderas {operation} som kommaseparerade värden (1,2,3,...,n) och tryck enter: ");
                            receivedLineAddition = Console.ReadLine();
                            try
                            {
                                bool isOkForAdding = AddNumbersToArray(receivedLineAddition);
                                if (isOkForAdding)
                                    isNotCorrectAdditionFormat = false;
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }

                        decimal receivedArraySumAddition = AddNumbers(num1, num2, numbersArray);

                        sbNumbers.AppendLine(receivedLineAddition);
                        sbNumbers.Replace(",", " + ");
                        sbNumbers.Remove(sbNumbers.Length - 1, 1);
                        sbNumbers.Insert(sbNumbers.Length - 1, " = ");
                        sbNumbers.Insert(sbNumbers.Length - 1, receivedArraySumAddition.ToString());
                        string stringToWriteForAddition = sbNumbers.ToString();

                        Console.WriteLine(stringToWriteForAddition);
                        ReadKey();
                        Array.Clear(numbersArray, 0, numbersArray.Length);
                        Array.Resize(ref numbersArray, 0);
                        sbNumbers.Clear();
                        break;

                    case ConsoleKey.D3:
                        Console.WriteLine();
                        operation = "-";

                        Console.WriteLine($"Ange första numret _ {operation} och tryck enter: ");
                        num1 = ReadNumber();
                        Console.WriteLine($"Ange andra numret {num1} {operation} _ och tryck enter: ");
                        num2 = ReadNumber();

                        decimal receivedDifference = SubtractNumbers(num1, num2, numbersArray);
                        Console.Write($"{num1} - {num2} = ");
                        Console.WriteLine(receivedDifference);
                        ReadKey();
                        break;

                    case ConsoleKey.D4:
                        Console.WriteLine();
                        operation = "- - - ...";

                        bool isNotCorrectSubtractionFormat = true;
                        string receivedLineSubtraction = "";

                        while (isNotCorrectSubtractionFormat)
                        {
                            Console.WriteLine($"Ange nummer som ska adderas {operation} som kommaseparerade värden (1,2,3,...,n) och tryck enter: ");
                            receivedLineSubtraction = Console.ReadLine();
                            try
                            {
                                bool isOkForSubtracting = AddNumbersToArray(receivedLineSubtraction);
                                if (isOkForSubtracting)
                                    isNotCorrectSubtractionFormat = false;
                            }
                            catch(FormatException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }

                        decimal receivedArrayDifferenceSubtraction = SubtractNumbers(num1, num2, numbersArray);

                        sbNumbers.AppendLine(receivedLineSubtraction);
                        sbNumbers.Replace(",", " - ");
                        sbNumbers.Remove(sbNumbers.Length - 1, 1);
                        sbNumbers.Insert(sbNumbers.Length - 1, " = ");
                        sbNumbers.Insert(sbNumbers.Length - 1, receivedArrayDifferenceSubtraction.ToString());
                        string stringToWriteForSubtraction = sbNumbers.ToString();

                        Console.WriteLine(stringToWriteForSubtraction);
                        ReadKey();
                        Array.Clear(numbersArray, 0, numbersArray.Length);
                        Array.Resize(ref numbersArray, 0);
                        sbNumbers.Clear();
                        break;

                    case ConsoleKey.D5:
                        Console.WriteLine();
                        operation = "*";

                        Console.WriteLine($"Ange första numret _ {operation} och tryck enter: ");
                        num1 = ReadNumber();
                        Console.WriteLine($"Ange andra numret {num1} {operation} _ och tryck enter: ");
                        num2 = ReadNumber();

                        decimal receivedProduct = MultiplyNumbers(num1, num2);
                        Console.Write($"{num1} * {num2} = ");
                        Console.WriteLine(receivedProduct);
                        ReadKey();
                        break;

                    case ConsoleKey.D6:
                        Console.WriteLine();
                        operation = "/";
                        
                        Console.WriteLine($"Ange första numret _ {operation} och tryck enter: ");
                        num1 = ReadNumber();

                        num2 = 0; //Resets num2
                        decimal receivedQuotient = 0;
                        while (num2 == 0)
                        {
                            Console.WriteLine($"Ange andra numret {num1} {operation} _ och tryck enter: ");
                            num2 = ReadNumber();
                            try
                            {
                                receivedQuotient = DivideNumbers(num1, num2);

                            }
                            catch(DivideByZeroException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }

                        Console.Write($"{num1} / {num2} = ");
                        Console.WriteLine(receivedQuotient);
                        ReadKey();
                        break;

                    case ConsoleKey.D7:
                        Console.WriteLine();
                        operation = "Sqrt";

                        Console.WriteLine($"Ange numret {operation}(_) och tryck enter: ");
                        num1 = ReadNumber();

                        double receivedSquareRoot = SquareRootOfNumber(num1);
                        Console.Write($"Sqrt({num1}) = ");
                        Console.WriteLine(receivedSquareRoot);
                        ReadKey();
                        break;

                    case ConsoleKey.D8:
                        Console.WriteLine();
                        operation = "^";

                        Console.WriteLine($"Ange första numret _ {operation} och tryck enter: ");
                        num1 = ReadNumber();
                        Console.WriteLine($"Ange andra numret {num1} {operation} _ och tryck enter: ");
                        num2 = ReadNumber();

                        double receivedPowered = PoweredToNumbers(num1, num2);
                        Console.Write($"{num1}^{num2} = ");
                        Console.WriteLine(receivedPowered);
                        ReadKey();
                        break;

                    case ConsoleKey.D9:
                        Console.WriteLine();
                        operation = "%";

                        Console.WriteLine($"Ange första numret _ {operation} av och tryck enter: ");
                        num1 = ReadNumber();
                        Console.WriteLine($"Ange andra numret {num1} {operation} av _ och tryck enter: ");
                        num2 = ReadNumber();

                        decimal receivedValue = PercentOfNumbers(num1, num2);
                        Console.Write($"{num1} % av {num2} = ");
                        Console.WriteLine(receivedValue);
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

        private static decimal ReadNumber()
        {
            bool isNotNumber = true;
            decimal value = 0;

            while(isNotNumber)
            {
                try
                {
                    string number = Console.ReadLine();
                    
                    if(Decimal.TryParse(number, out value))
                        isNotNumber = false;
                    else
                        throw new Exception("Fel: Mata in ett nummer!");
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return value;
        }

        private static void ReadKey()
        {
            Console.WriteLine();
            Console.WriteLine("Tryck på valfri tangent för att återvända till menyn: ");
            Console.ReadKey();
            Console.Clear();
        }

        public static decimal AddNumbers(decimal num1, decimal num2, decimal[] numbers)
        {
            decimal sum = 0;

            if (numbers.Length == 0)
            {
                decimal addend1 = num1;
                decimal addend2 = num2;
                sum = addend1 + addend2;
            }
            else 
            {
                sum = numbers.Sum();
            }

            return sum;
        }

        public static bool AddNumbersToArray(string line)
        {
            bool addedNumbers = false;
            bool parsed = true;

            string[] tempArray = line.Split(',');
            Array.Resize(ref numbersArray, tempArray.Length);
            
            for (int i = 0; i < tempArray.Length; i++)
            {
                decimal conversion = 0;
                parsed = decimal.TryParse(tempArray[i], out conversion);
                if (parsed == false)
                    break;
            }

            if (parsed == true)
            {
                for (int j = 0; j < tempArray.Length; j++)
                {
                    numbersArray[j] = Convert.ToDecimal(tempArray[j]);
                }

                addedNumbers = true;
            }
            else
            {
                throw new FormatException("Fel: Fel format. Ange rätt format på inmatning!");
            }

            return addedNumbers;
        }

        public static decimal SubtractNumbers(decimal num1, decimal num2, decimal[] numbers)
        {
            decimal difference = 0;

            if(numbers.Length == 0)
            {
                decimal minuend = num1;
                decimal subtrahend = num2;
                difference = minuend - subtrahend;
            }
            else
            {
                int index = 0;
                foreach(decimal number in numbers)
                {
                    if(index == 0)
                    {
                        difference = number;
                    }
                    else
                    {
                        difference -= number;
                    }
                    index++;
                }
            }

            return difference;
        }

        public static decimal MultiplyNumbers(decimal num1, decimal num2)
        {
            decimal multiplicand = num1;
            decimal multiplier = num2;
            decimal product = multiplicand * multiplier;
            
            return product;
        }

        public static decimal DivideNumbers(decimal num1, decimal num2)
        {
            decimal dividend = num1;
            decimal divisor = num2;

            decimal quotient = 0;

            if(num2 == 0)
            {
                throw new DivideByZeroException("Fel: Det är inte tillåtet att dividera med 0!");
            }
            
            quotient = dividend / divisor;
            
            return quotient;
        }

        public static double SquareRootOfNumber(decimal num1) 
        {
            double radicand = (double)num1;
            double squareRoot = Math.Sqrt(radicand);

            return squareRoot;
        }

        public static double PoweredToNumbers(decimal num1, decimal num2) 
        {
            double baseNumber = (double)num1;
            double exponent = (double)num2;
            double powered = Math.Pow(baseNumber, exponent);

            return powered;
        }

        public static decimal PercentOfNumbers(decimal num1, decimal num2) 
        {
            decimal percent = num1;
            decimal whole = num2;
            decimal calculatedValue = (whole / 100) * percent;
            
            return calculatedValue;
        }
    }
}
