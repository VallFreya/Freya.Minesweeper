using Freya.Minesweeper.Core.DimensionsField;

namespace Freya.Minesweeper.Core.Difficulty
{
    public abstract class BaseDefficulty
    {
        public BaseDefficulty()
        {
        }

        public BaseDefficulty(TypeOfDifficulty typeOfDifficulty, DimentionFieldBase field, int numberOfMine)
        {

        }

        /// <summary>
        /// Сложность игры
        /// </summary>
        public TypeOfDifficulty TypeOfDifficulty = TypeOfDifficulty.Easy;

        /// <summary>
        /// Свойства поля
        /// </summary>
        public DimentionFieldBase Field = new SmallDimentionsField();

        /// <summary>
        /// Количество мин
        /// </summary>
        public int NumberOfMine = 10;
    }
}
