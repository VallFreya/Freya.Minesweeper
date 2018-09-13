using Freya.Minesweeper.Core.Mines;
using System.Collections.Generic;

namespace Freya.Minesweeper.Core
{
    /// <summary>
    /// Класс представляющий поле
    /// </summary>
    public class Field
    {
        public Field(int horisontalNumbersOfCells, int verticalyNumberOfCells)
        {
            Cells = new Cell[horisontalNumbersOfCells, verticalyNumberOfCells];
        }

        /// <summary>
        /// Массив ячеек, описывающих поле
        /// </summary>
        public Cell[,] Cells { get; set; }

        public void ShowAllMine()
        {
            for (var x = 0; x < Cells.GetLength(0); x++)
            {
                for (int y = 0; y < Cells.GetLength(1); y++)
                {
                    if (Cells[x, y].Mine is MineBase)
                    {
                        Cells[x, y].SetShowForTrue();
                    }
                }
            }
        }

        public static IEnumerable<Cell> GetAllCellsAround(Field field, Cell cell)
        {
            for(int x = -1; x <= 1; x++)
            {
                for(int y = -1; y <= 1; y++)
                {
                    if (cell.X + x < 0 || cell.Y + y < 0)
                    {
                        continue;
                    }

                    if(cell.X + x >= field.Cells.GetLength(0) || cell.Y + y >= field.Cells.GetLength(1))
                    {
                        continue;
                    }
                    
                    yield return field.Cells[cell.X + x, cell.Y + y];
                }
            }
        }
    }
}
