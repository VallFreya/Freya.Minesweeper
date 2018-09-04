namespace Freya.Minesweeper.Logic.Interfaces
{
    /// <summary>
    /// Интерфейс описывающий механизм заполнения поля минами
    /// </summary>
    public interface IMechanismFillingField
    {
        /// <summary>
        /// Метод заполнения поля минами
        /// </summary>
        /// <param name="numberOfMine">Количество мин</param>
        /// <param name="horisontalNumbersOfCells">Количество клетов по горизонтали</param>
        /// <param name="verticalyNumberOfCells">Количество клеток по вертикали</param>
        /// <returns></returns>
        int?[,] Fill(int numberOfMine, int horisontalNumbersOfCells, int verticalyNumberOfCells);
    }
}
