using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorForFloatNumbers
{
    public class AdditionalCode
    {
        private static string PosDecToCode(int number)
        {
            StringBuilder builder = new StringBuilder();

            do
            {
                Console.WriteLine($"Делим с остатком {number} на {2}, остаток приписываем к результату. ");

                int mod = number % 2;

                builder.Append(mod);
                number /= 2;
            }
            while (number >= 2);

            if (number != 0)
            {
                builder.Append(number);
            }
            Console.WriteLine($"Полученное число {string.Join("", builder.ToString())} необходимо записать в обратном порядке.");
            Console.WriteLine($"Итог: {string.Join("", builder.ToString().Reverse())}");
            return string.Join("", builder.ToString().Reverse());
        }
        private static string NegDecToCode(int number)
        {
            Console.WriteLine($"Число {number} запишем по модулю {Math.Abs(number)}, после переведем его в двоичный код как положительное число.");
            Console.WriteLine();

            string str = PosDecToCode(Math.Abs(number));
            

        }
        public static List<int> DecToCode(string number)
        {
            if (int.TryParse(number, out int result))
            {
                if (result >= 0) PosDecToCode(result);
                else
                {

                }


            }




        }



    }
}
