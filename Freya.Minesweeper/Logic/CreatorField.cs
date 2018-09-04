using Freya.Minesweeper.Core.Difficulty;
using Freya.Minesweeper.Core.DimensionsField;

namespace Freya.Minesweeper.Logic
{
    /// <summary>
    /// Класс для создания поля
    /// </summary>
    public class CreatorField
    {
        /// <summary>
        /// Сложность
        /// </summary>
        private static BaseDefficulty Defficulty;
        
        public static int?[,] Create()
        {
            Defficulty = new EasyDefficulty();
            return CreateField();
        }

        public static int?[,] Create(BaseDefficulty defficulty)
        {
            Defficulty = defficulty;
            return CreateField();
        }

        private static int?[,] CreateField()
        {
            DimentionsFieldBase dimensionsField = Defficulty.GetField();
            return new MechanismRandomFillField().Fill(Defficulty.NumberOfMine, dimensionsField.HorisontalNumbersOfCells, dimensionsField.VerticalyNumberOfCells);
        }
    }
}
