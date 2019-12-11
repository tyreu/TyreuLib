﻿using System;

namespace Tyreu
{
    public class Complex
    {
        /// <summary>
        /// Мнимая часть
        /// </summary>
        public double Im { get; set; }
        /// <summary>
        /// Действительная часть
        /// </summary>
        public double Re { get; set; }
        public Complex() => Im = Re = 0.0;
        public Complex(double a, double b)
        {
            Im = a;
            Re = b;
        }
        public double Module { get => Math.Sqrt(Im * Im + Re * Re); }
        public static Complex operator +(Complex A, Complex B) => new Complex(A.Im + B.Im, A.Re + B.Re);
        public static Complex operator -(Complex A, Complex B) => new Complex(A.Im - B.Im, A.Re - B.Re);
        public static Complex operator *(Complex A, Complex B) => new Complex(A.Im * B.Im - A.Re * B.Re, A.Im * B.Re + A.Re * B.Im);
        public static Complex operator /(Complex A, Complex B) => new Complex((A.Im * B.Im + A.Re * B.Re) / (B.Im * A.Im + A.Re * A.Re), (A.Re * B.Im - A.Im * B.Re) / (A.Im * A.Im + A.Re * A.Re));
        public static Complex operator ^(Complex A, double n)
        {
            double Phi = n * Math.Atan2(A.Re, A.Im);
            A.Im = Math.Pow(A.Module, n) * Math.Cos(Phi);
            A.Re = Math.Pow(A.Module, n) * Math.Sin(Phi);
            return A;
        }
        public override string ToString() => $"{Im}{(Re > 0 ? "+" : "")}{Re}i";
    }
}
