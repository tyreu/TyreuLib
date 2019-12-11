namespace Tyreu
{
    namespace Shapes
    {
        using static System.Math;
        public class Circle : Shape
        {
            public Circle(double radius = 0)
            {
                Radius = radius;
            }
            public double Radius { get; set; }
            public double Diameter => 2 * Radius;

            public override double Area => PI * Radius * Radius;
            public override double Perimeter => 2 * PI * Radius;


            /// <summary>
            /// Вычислияет площадь сектора
            /// </summary>
            /// <param name="alpha">Угловая величина дуги (в градусах)</param>
            public double SectorSquare(double alpha) => Area * alpha / 360;
            /// <summary>
            /// Длина хорды через центральный угол и радиус
            /// </summary>
            public double ChordLengthByCentralAngle(double alpha) => Diameter * Sin(alpha / 2);
            /// <summary>
            /// Длина хорды через вписанный угол и радиус
            /// </summary>
            public double ChordLengthByInnerAngle(double alpha) => Diameter * Sin(alpha);
            /// <summary>
            /// Длина дуги через центральный угол
            /// </summary>
            /// <param name="alpha">Угловая величина дуги (в градусах)</param>
            public double ArcLength(double alpha) => PI * Radius * alpha / 180;
        }
    }
}