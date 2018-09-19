using Freya.Minesweeper.Core;
using Freya.Minesweeper.Core.Defficulty;
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

        public static Field Create()
        {
            Defficulty = new EasyDefficulty();
            return CreateField();
        }

        public static Field Create(BaseDefficulty defficulty)
        {
            Defficulty = defficulty;
            return CreateField();
        }

        private static Field CreateField()
        {
            DimentionsFieldBase dimensionsField = Defficulty.GetField();
            var field = new MechanismRandomFillField().Fill(Defficulty.NumberOfMine, dimensionsField.HorisontalNumbersOfCells, dimensionsField.VerticalyNumberOfCells);
            return SetterCountMine.Set(field);
        }
    }
}
