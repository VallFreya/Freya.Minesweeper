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
    }
}
