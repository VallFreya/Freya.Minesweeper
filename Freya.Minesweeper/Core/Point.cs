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
        private int X { get; set; }

        /// <summary>
        /// Вертикальная ось
        /// </summary>
        private int Y { get; set; }

        public Point Get()
        {
            return this;
        }

        public override string ToString()
        {
            return $"{X}:{Y}";
        }
    }
}
