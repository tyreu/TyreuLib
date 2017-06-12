using System;
using System.Text;

namespace Tyreu
{
    public class Converter
    {
        /// <summary>
        /// Переводит число из 10-ичной системы счисления в указанную
        /// </summary>
        /// <param name="number">Число для перевода из 10 в другую систему счисления</param>
        /// <param name="base">Основание системы счисления</param>
        /// <returns>Возвращает строковое представление переведенного числа</returns>
        string ConvertFrom10(string number, int @base = 10)
        {
            string res = string.Empty; // хранит ответ, т.e. двоичное представление входного целого числа
            int num = int.Parse(number);
            while (num != 0) // пока входное число не стало НУЛЕМ
            {
                int rem = num % @base; // отвечает за остаток при делении текущего number
                num /= @base; // уменьшаем входное в base раз
                if (rem > 9) // если остаток больше 9, т е переводим в систему счисления по основанию больше чем 10
                {
                    rem += 'A' - 10;  // заменяем двузначные числа их символьными эквивалентами, т е 10 -> 'A', 11 -> 'B', ..., 15 -> 'F'
                    res = (char)rem + res;     // добавляем остаток в начало ответа
                }
                else
                    res = rem.ToString() + res;
            }
            return res;
        }
        /// <summary>
        /// Переводит число из указанной системы счисления в 10-ичную
        /// </summary>
        /// <param name="number">Число для перевода из указанной системы счисления в 10</param>
        /// <param name="base">Основание системы счисления</param>
        /// <returns>Возвращает целое число в 10-ичной системе счисления</returns>
        int ConvertTo10(string number, int @base)
        {
            number = number.ToUpper();
            int res = 0;
            for (int i = number.Length - 1, j = 0; i >= 0; i--, j++) 
                res += (int)((number[i] - (number[i] >= 'A' && number[i] <= 'F' ? 55 : '0')) * Math.Pow(@base, j));
            return res;
        }
        /// <summary>
        /// Переводит число из начальной системы счисления в конечную
        /// </summary>
        /// <param name="beginBase">Начальное основание числа</param>
        /// <param name="number">Число для преобразования</param>
        /// <param name="endBase">Конечное основание системы счисления</param>
        /// <returns>Возвращает строковое представление переведенного числа</returns>
        public string Convert(string number, int beginBase, int endBase)
        {
            return beginBase == 10 ? ConvertFrom10(number, endBase) :
                   endBase == 10 ? ConvertTo10(number, beginBase).ToString() :
                   ConvertFrom10(ConvertTo10(number, beginBase).ToString(), endBase);
        }
        /// <summary>
        /// Переводит строку текста в цифровое представление нужной системы счисления
        /// </summary>
        /// <param name="text">Строка для перевода</param>
        /// <param name="base">Система счисления</param>
        /// <returns></returns>
        public string Convert(string text, int @base)
        {
            string result = string.Empty;
            try
            {
                if (@base < 2) throw new ArgumentException("Основание системы счисления должно быть больше 1");
                byte[] array = Encoding.UTF8.GetBytes(text);
                foreach (var item in array)
                    result += ConvertFrom10(item.ToString(), @base);
            }
            catch(ArgumentException ex) { return ex.Message; }
            return result;
        }
    }
}