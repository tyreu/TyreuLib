using System;
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
            char[] mas1 = str1.ToCharArray(), mas2 = str2.ToCharArray();
            Array.Sort(mas1);
            Array.Sort(mas2);
            return string.Join(null, mas1) == string.Join(null, mas2);
        }
        /// <summary>
        /// Возводит первый символ каждого слова в верхний регистр
        /// </summary>
        /// <param name="str">Строка для преобразования ее первых символов</param>
        /// <returns></returns>
        public static string FirstCharUp(string str, char separator = ' ')
        {
            string[] words = str.Split(' ');//разбили на слова
            string result = "";
            foreach (string s in words)
            {

                char[] temp = s.ToCharArray();//преобразовали в массив символов
                //если символ нижнего регистра, ставим его в верхний регистр
                temp[0] = !char.IsUpper(temp[0]) ? char.ToUpper(temp[0]) : temp[0];
                result += string.Join(null, temp) + " ";
            }
            return result;
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
            char[] bracketsArray = brackets.ToCharArray();
            int open = bracketsArray.Where(bracket => pairs.Keys.Contains(bracket)).Count(),
                close = bracketsArray.Where(bracket => pairs.Values.Contains(bracket)).Count();
            if (open == close)
            {
                for (int i = brackets.Length / 2, j = i - 1; i < brackets.Length && pairs.TryGetValue(bracketsArray[j], out int code); bracketsArray[i] = (char)code, i++, j--) ;
                return string.Join(" ", bracketsArray);
            }
            else return "null";
        }
    }
}