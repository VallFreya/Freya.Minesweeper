using Freya.Minesweeper.Core.Mines;

namespace Freya.Minesweeper.Core
{
    /// <summary>
    /// Класс представляющий ячейку
    /// </summary>
    public class Cell : Point
    {
        public Cell(Cell cell) : base(cell.X, cell.Y)
        {
            Mine = cell.Mine;
            CountMineAround = cell.CountMineAround;
            IsShow = cell.IsShow;
        }

        public Cell(MineBase mine, int x, int y) : base(x, y)
        {
            Mine = mine;
        }

        public Cell(int countMineAround, int x, int y): base(x, y)
        {
            CountMineAround = countMineAround;
        }

        /// <summary>
        /// Объект мины в ячкейке
        /// </summary>
        public MineBase Mine { get; private set; }

        /// <summary>
        /// Количество мин вокруг ячейки
        /// </summary>
        public int CountMineAround { get; private set; }

        /// <summary>
        /// Свойство показа данной ячейки
        /// </summary>
        public bool IsShow { get; set; }

        public void SetShowForTrue()
        {
            IsShow = true;
        }
    }
}
