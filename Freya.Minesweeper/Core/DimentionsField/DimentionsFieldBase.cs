namespace Freya.Minesweeper.Core.DimentionsField
{
    /// <summary>
    /// Базовый класс описывающий свойсва поля
    /// </summary>
    public abstract class DimentionsFieldBase
    {
        public DimentionsFieldBase()
        {
        }

        public DimentionsFieldBase(int horisontalNumbersOfCells, int verticalyNumberOfCells, TypeOfDimensionsField typeOfDimensionsField)
        {
            HorisontalNumbersOfCells = horisontalNumbersOfCells;
            VerticalyNumberOfCells = verticalyNumberOfCells;
            TypeOfDimensionsField = typeOfDimensionsField;
        }

        /// <summary>
        /// Тип размера поля
        /// </summary>
        private readonly TypeOfDimensionsField TypeOfDimensionsField = TypeOfDimensionsField.Small;

        /// <summary>
        /// Количество ячеек по горизонтали
        /// </summary>
        public int HorisontalNumbersOfCells { get; } = 9;

        /// <summary>
        /// Количество клеток по горизонтали
        /// </summary>
        public int VerticalyNumberOfCells { get;  } = 9;
    }
}
