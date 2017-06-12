using System;
using System.Linq;
namespace Tyreu
{
    static class String
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
    }
}