namespace Freya.Minesweeper.Core
{
    /// <summary>
    /// Точка на плоскости
    /// </summary>
    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Горизонтальная ось
        /// </summary>
        public int X { get; private set; }

        /// <summary>
        /// Вертикальная ось
        /// </summary>
        public int Y { get; private set; }

        public void SetX(int x)
        {
            X = x;
        }

        public void SetY(int y)
        {
            Y = y;
        }

        public override string ToString()
        {
            return $"{X}:{Y}";
        }
    }
}
