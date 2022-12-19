using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorForFloatNumbers
{
    public class Sum
    {
        private static int FromBinToDec(string number)
        {
            int result = 0;

            int num;

            for (int i = 0; i < number.Length; i++)
            {
                char c = number[i];

                if (c >= '0' && c <= '9')
                    num = c - '0';
                else if (c >= 'A' && c <= 'Z')
                    num = c - 'A' + 10;
                else if (c >= 'a' && c <= 'z')
                    num = c - 'a' + (('Z' - 'A') + 1) + 10;
                else throw new ArgumentException("Invalid number");

                Console.WriteLine($"Умножаем результат на основание ситемы: {2},  прибавляем число: {num}, отвечающее за {i + 1} позицию числа.");

                result *= 2;
                result += num;

                Console.WriteLine($"({result / 2} * {2}) + {num} = {result}");
            }
            return result;
        }
        private static int ConvertSymbolToNumber(char num)
        {
            int n = (int)num;
            if (n >= 48 && n <= 57) n = n - '0';
            if (n >= 65 && n <= 90) n = n - 'A' + 10;
            if (n >= 97 && n <= 122) n = n - 'a' + 36;

            return n;
        }       
        public static void SumAddCodeForInt(string number1, string number2, int a, int b)
        {

            int[] mass1 = new int[number1.Length];
            int[] mass2 = new int[number2.Length];
            int[] mass3 = new int[Math.Max(mass1.Length, mass2.Length)];

            char[] result = new char[Math.Max(mass1.Length, mass2.Length)];

            for (int i = 0; i < number1.Length; i++)
            {
                mass1[i] = ConvertSymbolToNumber(number1[i]);
            }

            for (int i = 0; i < number2.Length; i++)
            {
                mass2[i] = ConvertSymbolToNumber(number2[i]);
            }
            bool flag = true;
            int newDigit = 1;
            Console.WriteLine($"{number1} + {number2} ");
            for (int i = 0; i < Math.Max(mass1.Length, mass2.Length); i++)
            {
                if (mass1.Length - 1 - i >= 0 && mass2.Length - 1 - i >= 0)
                {
                    mass3[mass3.Length - 1 - i] = mass3[mass3.Length - 1 - i] + mass1[mass1.Length - 1 - i] + mass2[mass2.Length - 1 - i];
                    Console.WriteLine($"Складываем {mass1[mass1.Length - 1 - i]} + {mass2[mass2.Length - 1 - i]} и прибавляем число {mass3[mass3.Length - 1 - i] - mass1[mass1.Length - 1 - i] - mass2[mass2.Length - 1 - i]} лежащие в этом разряде появивщиеся из-за переносов");
                }
                if (mass1.Length - 1 - i < 0)
                {
                    mass3[mass3.Length - 1 - i] += mass2[mass2.Length - 1 - i];
                    Console.WriteLine($"записываем в {i} разряд занчение {mass2[mass2.Length - 1 - i]}, так как первое число имеет на этих позициях незначащие нули");
                }
                if (mass2.Length - 1 - i < 0)
                {
                    mass3[mass3.Length - 1 - i] += mass1[mass1.Length - 1 - i];
                    Console.WriteLine($"записываем в {i} разряд занчение {mass1[mass1.Length - 1 - i]}, так как второе число имеет на этих позициях незначащие нули");
                }
                if (mass3[mass3.Length - 1 - i] >= 2)
                {
                    Console.WriteLine($"Число {mass3[mass3.Length - 1 - i]} в позиции {i + 1} больше основания ситемы, то вычиатем из него {2} и прибавляем на {i + 2} позицию еденицу");
                    mass3[mass3.Length - 1 - i] -= 2;
                    if (mass3.Length - i - 2 >= 0) mass3[mass3.Length - i - 2]++;
                    else flag = false;
                }
            }

            string str = null;

            str = string.Join("", mass3);
            Console.WriteLine($"Итог в двоичной системе счисления: {str}");

            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine();

            Console.WriteLine($"Итог в десятичной системе счисления: {FromBinToDec(str)}");
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine();
        }
    }
}
