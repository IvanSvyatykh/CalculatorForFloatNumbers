using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorForFloatNumbers
{
    public class AdditionalCode
    {
        private static StringBuilder NormalizeStringBuilder(StringBuilder builder)
        {
            int length = builder.Length;
            int count = 0;
            while (length - 2 >= 0)
            {
                length -= 2;
                count++;
            }

            if (Math.Pow(2, count) < builder.Length) count++;

            StringBuilder builder1 = new StringBuilder();

            for (int i = 0; i < Math.Pow(2, count) - builder.Length; i++)
            {
                builder1.Append("0");
            }

            return builder.Append(builder1);
        }
        private static string PosDecToCode(int number)
        {
            StringBuilder builder = new StringBuilder();

            do
            {
                Console.WriteLine($"Делим с остатком {number} на {2}, остаток приписываем к результату.");

                int mod = number % 2;

                builder.Append(mod);
                number /= 2;
            }
            while (number >= 2);

            if (number != 0)
            {
                builder.Append(number);
            }

            builder = NormalizeStringBuilder(builder);

            Console.WriteLine($"Полученное число {string.Join("", builder.ToString())} необходимо записать в обратном порядке");
            Console.WriteLine($"Итог: {string.Join("", builder.ToString().Reverse())}");

            return string.Join("", builder.ToString().Reverse());
        }
        private static string NegDecToCode(int number)
        {
            Console.WriteLine($"Число {number} запишем по модулю {Math.Abs(number)}, после переведем его в двоичный код как положительное число");
            Console.WriteLine();

            string str = PosDecToCode(Math.Abs(number));
            List<int> list = new List<int>();
            Console.WriteLine($"Полученное число будем преобразовывать таким образом, сначала инверитируем числа на каждой позиции, а после прибавим единицу в конец");

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '0')
                {
                    Console.WriteLine($"Так как {i + 1} позиции стоит 0 запишем на этом месте 1");
                    list.Add(1);
                }
                else if (str[i] == '1')
                {
                    Console.WriteLine($"Так как {i + 1} позиции стоит 1 запишем на этом месте 0");
                    list.Add(0);
                }
            }

            bool flag = true;

            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (flag)
                {
                    list[i]++;
                    flag = false;
                }
                if (list[i] == 1 || list[i] == 0) break;
                else if (list[i] == 2)
                {
                    list[i] -= 2;
                    if (i - 1 >= 0) list[i - 1]++;
                    else list.Insert(0, 1);
                }

            }

            return string.Join("", list); ;
        }
        public static void DecToCode(string number)
        {
            if (int.TryParse(number, out int result))
            {
                if (result >= 0) Console.WriteLine($"{number} в дополонительном коде :{PosDecToCode(result)}");
                else
                {
                    Console.WriteLine($"{number} в дополонительном коде :{NegDecToCode(result)}");
                }
            }
        }
    }
}
