using System.Collections.Generic;
using System.Linq;

namespace Tyreu
{
    public static class String
    {
        /// <summary>
        /// Определяет, являются ли слова анаграммами
        /// </summary>
        /// <param name="str1">1 слово для проверки</param>
        /// <param name="str2">2 слово для проверки</param>
        /// <returns></returns>
        public static bool IsAnagram(string str1, string str2)
        {
            if (str1.Length != str2.Length)
            {
                return false;
            }
            for (int i = 0; i < str1.Length; i++)
            {
                if (!str2.Contains($"{str1[i]}"))
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Возводит первый символ каждого слова в верхний регистр
        /// </summary>
        /// <param name="str">Строка для преобразования ее первых символов</param>
        /// <returns></returns>
        public static string Capitalize(string str)
        {
            char[] array = str.ToCharArray();
            //Обрабатываем первую букву в строке
            if (array.Length >= 1)
            {
                if (char.IsLower(array[0]))
                {
                    array[0] = char.ToUpper(array[0]);
                }
            }
            // Проверяем на наличие пробела и возводим в верхний регистр следующий символ
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == ' ')
                {
                    if (char.IsLower(array[i]))
                    {
                        array[i] = char.ToUpper(array[i]);
                    }
                }
            }
            return new string(array);
            //return Regex.Replace(str, @"(^\w)|(\s\w)", m => m.Value.ToUpper());
        }
        /// <summary>
        /// Является ли символы строки кириллицей
        /// </summary>
        /// <param name="str">Строка для проверки</param>
        /// <returns></returns>
        public static bool IsAllCyrillic(string str) => str.ToLower().ToCharArray().All(c => c >= '\u0430' && c <= '\u0451');
        /// <summary>
        /// Является ли символы строки латиницей
        /// </summary>
        /// <param name="str">Строка для проверки</param>
        /// <returns></returns>
        public static bool IsAllLatin(string str) => str.ToUpper().ToCharArray().All(c => c >= '\u0041' && c <= '\u005a');
        /// <summary>
        /// Проверить правильность расстановки скобок
        /// </summary>
        /// <param name="brackets">Последовательность скобок</param>
        public static string CorrectBrackets(string brackets)
        {
            Dictionary<int, int> pairs = new Dictionary<int, int>() { { 40, 41 }, { 60, 62 }, { 91, 93 }, { 123, 125 } };//(), <>, [], {}
            char[] bracketsArray = brackets.Trim().Replace(" ", "").ToCharArray();
            int open = bracketsArray.Where(bracket => pairs.Keys.Contains(bracket)).Count(),
                close = bracketsArray.Where(bracket => pairs.Values.Contains(bracket)).Count();
            if (open == close)
            {
                for (int i = bracketsArray.Length / 2, j = i - 1; i < bracketsArray.Length && j >= 0 && pairs.TryGetValue(bracketsArray[j], out int code); bracketsArray[i] = (char)code, i++, j--) ;
                return string.Join(" ", bracketsArray);
            }
            else return "Incorrect";
        }
    }
}
