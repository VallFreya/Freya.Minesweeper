using Freya.Minesweeper.Core.Mines;
using System.Collections.Generic;

namespace Freya.Minesweeper.Core
{
    /// <summary>
    /// Класс представляющий поле
    /// </summary>
    public class Field
    {
        /*Перенести создание поля в этот класс или же...*/
        public Field(int horisontalNumbersOfCells, int verticalyNumberOfCells)
        {
            Cells = new Cell[horisontalNumbersOfCells, verticalyNumberOfCells];
            VerticalCount = verticalyNumberOfCells;
            HorizontalCount = horisontalNumbersOfCells;
        }

        /// <summary>
        /// Массив ячеек, описывающих поле
        /// </summary>
        public Cell[,] Cells { get; set; }

        public int VerticalCount { get; }

        public int HorizontalCount { get; }

        public bool IsOutside(Cell cell)
        {
            if (cell.X < 0 || cell.Y < 0)
            {
                return true;
            }

            if (cell.X >= HorizontalCount || cell.Y >= VerticalCount)
            {
                return true;
            }

            return false;
        }

        public void ShowAllMines()
        {
            var allCells = GetAllCells();
            foreach (var cell in allCells)
            {
                if (cell.Mine is MineBase)
                {
                    cell.Show();
                }
            }
        }

        public IEnumerable<Cell> GetAllCellsAround(Cell cell)
        {
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (cell.X + x < 0 || cell.Y + y < 0)
                    {
                        continue;
                    }

                    if (cell.X + x >= HorizontalCount || cell.Y + y >= VerticalCount)
                    {
                        continue;
                    }

                    yield return Cells[cell.X + x, cell.Y + y];
                }
            }
        }

        public IEnumerable<Cell> GetAllCells()
        {
            for (var x = 0; x < HorizontalCount; x++)
            {
                for (int y = 0; y < VerticalCount; y++)
                {
                    yield return Cells[x, y];
                }
            }
        }
    }
}
