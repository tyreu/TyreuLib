namespace Tyreu
{
    namespace Shapes
    {
        public class Circle
        {
            public Circle() => Radius = 0;
            public Circle(double radius) => Radius = radius;
            public double Diameter => 2 * Radius;
            public double Radius { get; set; }
            const double Pi = System.Math.PI;
            public double Square => Pi * Radius * Radius;
            public double Length => 2 * Pi * Radius;
            /// <summary>
            /// Вычислияет площадь сектора
            /// </summary>
            /// <param name="alpha">Угловая величина дуги (в градусах)</param>
            public double SectorSquare(double alpha) => Square * alpha / 360;
            /// <summary>
            /// Длина хорды через центральный угол и радиус
            /// </summary>
            public double ChordLengthByCentralAngle(double alpha) => Diameter * System.Math.Sin(alpha / 2);
            /// <summary>
            /// Длина хорды через вписанный угол и радиус
            /// </summary>
            public double ChordLengthByInnerAngle(double alpha) => Diameter * System.Math.Sin(alpha);
            /// <summary>
            /// Длина дуги через центральный угол
            /// </summary>
            /// <param name="alpha">Угловая величина дуги (в градусах)</param>
            public double ArcLength(double alpha) => Pi * Radius * alpha / 180;
        }
    }
}