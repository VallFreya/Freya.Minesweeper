using Freya.Minesweeper.Core.Mines;
using Freya.Minesweeper.CustomUIElement;
using System.Collections.Generic;
using System.Linq;

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
            VerticalyCount = verticalyNumberOfCells;
            HorisontalCount = horisontalNumbersOfCells;
        }

        /// <summary>
        /// Массив ячеек, описывающих поле
        /// </summary>
        private Cell[,] Cells { get; set; }

        public void SetCell(Cell cell)
        {
            Cells[cell.X, cell.Y] = cell;
        }

        public Cell GetCell(int x, int y)
        {
            if(IsOutside(new Cell(x, y)))
            {
                return null;
            }

            return Cells[x, y];
        }

        public int VerticalyCount { get; }

        public int HorisontalCount { get; }

        public bool IsOutside(Cell cell)
        {
            if (cell.X < 0 || cell.Y < 0)
            {
                return true;
            }

            if (cell.X >= HorisontalCount || cell.Y >= VerticalyCount)
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
                    var cellAround = GetCell(cell.X + x, cell.Y + y);
                    if (cellAround is null)
                    {
                        continue;
                    }

                    yield return cellAround;
                }
            }
        }

        public IEnumerable<Cell> GetAllCells()
        {
            for (var x = 0; x < HorisontalCount; x++)
            {
                for (int y = 0; y < VerticalyCount; y++)
                {
                    yield return GetCell(x, y);
                }
            }
        }

        public void ShowAllEmptyCells(MineButton button)
        {
            var listForOpen = new List<Cell>
            {
                GetCell(button.X, button.Y)
            };

            while (listForOpen.Count != 0)
            {
                var cell = listForOpen.First();
                int x = cell.X;
                int y = cell.Y;
                if (cell.CountMineAround == 0 || cell.Mine is MineBase)
                {
                    listForOpen.AddRange(GetAllCellsAround(cell)
                        .Where(c => c.IsShow == false 
                                && c.Mine is null
                                && c.Flag is Flag.Empty));
                }

                cell.Show();
                listForOpen.Remove(cell);
            }
        }

        public bool IsWin()
        {
            var allMines = GetAllCellsInMines();
            foreach(var mine in allMines)
            {
                if (!(mine.Flag is Flag.Flag))
                {
                    return false;
                }
            }

            return true;
        }

        public IEnumerable<Cell> GetAllCellsInMines()
        {
            var allCells = GetAllCells();
            foreach (var cell in allCells)
            {
                if(cell.Mine is MineBase)
                {
                    yield return cell;
                }
            }
        }

        public int GetNotSetFlagMines()
        {
            var mines = GetAllCellsInMines();
            var allMines = mines.Count();
            return allMines - GetAllCells().Where(x => x.Flag is Flag.Flag).Count();
        }
    }
}
