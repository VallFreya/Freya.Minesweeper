using Freya.Minesweeper.Core.DimensionsField;

namespace Freya.Minesweeper.Core.Defficulty
{
    public abstract class BaseDefficulty
    {
        public BaseDefficulty()
        {
        }

        public BaseDefficulty(TypeOfDifficulty typeOfDifficulty, DimentionsFieldBase field, int numberOfMine)
        {
            TypeOfDifficulty = typeOfDifficulty;
            Field = field;
            NumberOfMine = numberOfMine;
        }

        /// <summary>
        /// Сложность игры
        /// </summary>
        private readonly TypeOfDifficulty TypeOfDifficulty = TypeOfDifficulty.Easy;

        /// <summary>
        /// Свойства поля
        /// </summary>
        private readonly DimentionsFieldBase Field = new SmallDimentionField();

        /// <summary>
        /// Количество мин
        /// </summary>
        public int NumberOfMine { get; } = 10;
        
        public DimentionsFieldBase GetField()
        {
            return Field;
        }
    }
}
