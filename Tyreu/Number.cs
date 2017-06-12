﻿using System;
using System.Linq;
namespace Tyreu
{
    public static class Number
    {
        const double NaN = double.NaN;
        /// <summary>
        /// Возвращает максимальное значение (1.797696 ^ 308)
        /// </summary>
        /// <returns></returns>
        public static double Max() => double.MaxValue;
        /// <summary>
        /// Возвращает наибольшее из двух чисел
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double Max(double a, double b) => (a > b) ? a : b;
        /// <summary>
        /// Возвращает наибольшее число из одномерного массива чисел
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static double Max(params double[] array) => array.Max();
        /// <summary>
        /// Возвращает наибольшее число из двумерного массива чисел
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static double Max(double[,] array) => (from int x in array select x).Max();
        /// <summary>
        /// Возвращает минимальное значение (-1.797696 ^ 308)
        /// </summary>
        /// <returns></returns>
        public static double Min() => double.MinValue;
        /// <summary>
        /// Возвращает наименьшее из двух чисел
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double Min(double a, double b) => (a < b) ? a : b;
        /// <summary>
        /// Возвращает наименьшее число из одномерного массива чисел
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static double Min(params double[] array) => array.Min();
        /// <summary>
        /// Возвращает наименьшее число из двумерного массива чисел
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static double Min(double[,] array) => (from int x in array select x).Min();
        /// <summary>
        /// Находит а в степени b
        /// </summary>
        /// <param name="a">Число, степень которого надо найти</param>
        /// <param name="b">Степень, в которую возводится число a</param>
        /// <returns></returns>
        public static double Power(double a, double b) => (a == 0 || b == 0) ? 0 : Math.Exp(b * Math.Log(a));
        /// <summary>
        /// Складывает все элементы массива и возвращает сумму
        /// </summary>
        /// <param name="numbers">Массив чисел</param>
        /// <returns></returns>
        public static double Sum(params double[] numbers) => numbers.Sum();
        /// <summary>
        /// Умножает все элементы массива и возвращает произведение
        /// </summary>
        /// <param name="numbers">Массив чисел</param>
        /// <returns></returns>
        public static double Mul(params double[] numbers) => numbers.Aggregate((p, x) => p *= x);
    }
}