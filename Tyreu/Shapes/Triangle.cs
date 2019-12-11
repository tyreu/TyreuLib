using System;
namespace Tyreu
{
    namespace Shapes
    {
        public class Triangle : Shape
        {
            public Triangle() { A = 0; B = 0; C = 0; }
            public Triangle(double _a, double _b, double _c) { A = _a; B = _b; C = _c; }
            public double A { get; set; }
            public double B { get; set; }
            public double C { get; set; }
            public double Alpha => Math.Acos((B * B + C * C - A * A) / 2 * B * C);
            public double Beta => Math.Acos((A * A + C * C - B * B) / 2 * A * C);
            public double Gamma => Math.Acos((A * A + B * B - C * C) / 2 * A * B);
            /// <summary>
            /// Cвойство Периметр
            /// </summary>
            public override double Perimeter => A + B + C;
            /// <summary>
            /// Свойство Полупериметр
            /// </summary>
            public double Semiperimeter => Perimeter / 2;
            /// <summary>
            /// Свойство Площадь
            /// </summary>
            public override double Area => Math.Sqrt(Semiperimeter * (Semiperimeter - A) * (Semiperimeter - B) * (Semiperimeter - C));
            /// <summary>
            /// Существует ли такой треугольник
            /// </summary>
            /// <param name="a"></param>
            /// <param name="b"></param>
            /// <param name="c"></param>
            /// <returns></returns>
            public bool IsExist() => ((A + B > C) && (A + C > B) && (B + C > A));
            /// <summary>
            /// Находит третью стороны треугольника
            /// </summary>
            /// <param name="a">1 сторона</param>
            /// <param name="b">2 сторона</param>
            /// <param name="cos">Угол между этими сторонами</param>
            /// <returns></returns>
            public static double Find3Side(double a, double b, double cos) => Math.Sqrt(a * a + b * b - 2 * a * b * Math.Cos(cos * Math.PI / 180));
            /// <summary>
            /// Длина биссектрисы через две стороны и угол
            /// </summary>
            /// <param name="cos">Угол, разделенный биссектрисой пополам</param>
            /// <returns></returns>
            public double FindBisectrixByCos(double cos) => (2 * A * B * Math.Cos((cos * Math.PI / 180) / 2)) / (A + B);
            /// <summary>
            /// Длина биссектрисы через полупериметр и стороны
            /// </summary>
            /// <returns></returns>
            public double FindBisectrixBySemiperimeter() => (2 * Math.Sqrt(A * B * Semiperimeter * (Semiperimeter - C))) / (A + B);
            /// <summary>
            /// Длина биссектрисы через 3 ее стороны
            /// </summary>
            /// <returns></returns>
            public double FindBisectrixBySides() => Math.Sqrt(A * B * (A + B + C) * (A + B - C)) / (A + B);
            /// <summary>
            /// Высота треугольника
            /// </summary>
            /// <param name="length">Длина стороны, на которую опущена высота</param>
            /// <returns></returns>
            public double FindHeight(double length) => 2 * Area / length;
            /// <summary>
            /// Формула длины медианы через три стороны
            /// </summary>
            /// <returns></returns>
            public double FindMedian() => 1 / 2 * Math.Sqrt(2 * A * A + 2 * B * B - C * C);
            /// <summary>
            /// Формула длины медианы через две стороны и угол между ними
            /// </summary>
            /// <param name="cos">Угол, из которого пущена медиана</param>
            public double FindMedian(double cos) => 1 / 2 * Math.Sqrt(A * A + B * B + 2 * A * B * Math.Cos(cos));
        }
    }
}
