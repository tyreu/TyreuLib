using System;

namespace Tyreu
{
    namespace Shapes
    {
        public class Square : Shape
        {
            public Square(double side = 0)=> Side = side;
            /// <summary>
            /// Длина стороны
            /// </summary>
            public double Side { get; set; }
            /// <summary>
            /// Площадь
            /// </summary>
            public override double Area => Side * Side;
            /// <summary>
            /// Периметр
            /// </summary>
            public override double Perimeter => Side * 4;
            /// <summary>
            /// Диагональ квадрата
            /// </summary>
            public double Diagonal => Perimeter / (2 * Math.Sqrt(2));
            /// <summary>
            /// Радиус вписанной окружности
            /// </summary>
            public double InnerCircleRadius => Side / 2;
            /// <summary>
            /// Радиус описанной окружности
            /// </summary>
            public double OuterCircleRadius => Diagonal / 2;
        }
    }
}
