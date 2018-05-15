using System;

namespace Tyreu
{
    class Complex
    {
        double Im;
        double Re;
        public Complex() => Im = Re = 0.0;
        public Complex(double a, double b)
        {
            Im = a;
            Re = b;
        }
        public double Module { get => Math.Sqrt(Im * Im + Re * Re); }
        public static Complex operator +(Complex A, Complex B) => new Complex(A.Im + B.Im, A.Re + B.Re);
        public static Complex operator -(Complex A, Complex B) => new Complex(A.Im - B.Im, A.Re - B.Re);
        public static Complex operator *(Complex A, Complex B)
            => new Complex(A.Im * B.Im - A.Re * B.Re, A.Im * B.Re + A.Re * B.Im);
        public static Complex operator /(Complex A, Complex B)
            => new Complex((A.Im * B.Im + A.Re * B.Re) / (B.Im * A.Im + A.Re * A.Re), (A.Re * B.Im - A.Im * B.Re) / (A.Im * A.Im + A.Re * A.Re));
        public Complex Pow(double n)
        {
            double Phi = n * Math.Atan2(Re, Im);
            Im = Math.Pow(Module, n) * Math.Cos(Phi);
            Re = Math.Pow(Module, n) * Math.Sin(Phi);
            return new Complex(Im, Re);
        }
        public override string ToString() => $"{Im}{(Re > 0 ? "+" : "")}{Re}i";
    }
}
