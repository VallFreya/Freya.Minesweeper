using Freya.Minesweeper.Core.Mines;

namespace Freya.Minesweeper.Core
{
    /// <summary>
    /// Класс представляющий ячейку
    /// </summary>
    public class Cell : Point
    {
        public Cell(int x, int y) : base(x, y)
        {
        }

        public Cell(Cell cell) : base(cell.X, cell.Y)
        {
            Mine = cell.Mine;
            CountMineAround = cell.CountMineAround;
            IsShow = cell.IsShow;
        }

        public Cell SetMine(MineBase mine)
        {
            Mine = mine;
            return this;
        }

        public Cell SetCountMineAround(int countMineAround)
        {
            CountMineAround = countMineAround;
            return this;
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

        /// <summary>
        /// Пометка на клетке (Флаг, знак вопроса)
        /// </summary>
        public Flag Flag { get; private set; } = Flag.Empty;

        public void Show()
        {
            IsShow = true;
        }

        public void SetFlag()
        {
            Flag = Flag.Flag;
        }

        public void SetEmptyFlag()
        {
            Flag = Flag.Empty;
        }
    }
}
