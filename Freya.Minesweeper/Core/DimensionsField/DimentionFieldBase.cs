namespace Freya.Minesweeper.Core.DimensionsField
{
    /// <summary>
    /// Базовый класс описывающий свойсва поля
    /// </summary>
    public abstract class DimentionFieldBase
    {
        public DimentionFieldBase()
        {
        }

        public DimentionFieldBase(int horisontalNumbersOfCells, int verticalyNumberOfCells, TypeOfDimensionsField typeOfDimensionsField)
        {
            HorisontalNumbersOfCells = horisontalNumbersOfCells;
            VerticalyNumberOfCells = verticalyNumberOfCells;
            TypeOfDimensionsField = typeOfDimensionsField;
        }

        /// <summary>
        /// Тип размера поля
        /// </summary>
        private TypeOfDimensionsField TypeOfDimensionsField = TypeOfDimensionsField.Small;

        /// <summary>
        /// Количество ячеек по горизонтали
        /// </summary>
        private int HorisontalNumbersOfCells = 9;

        /// <summary>
        /// Количество клеток по горизонтали
        /// </summary>
        private int VerticalyNumberOfCells = 9;
    }
}
