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
            var field = new MechanismRandomFillField().Fill(Defficulty.NumberOfMine, dimensionsField.HorisontalNumbersOfCells, dimensionsField.VerticalyNumberOfCells);
            return SetCountMine(field);

        }

        /// <summary>
        /// Выделить в класс методы выставления числа мин вокруг ячейки
        /// </summary>
        /// <param name="field"></param>
        private static int?[,] SetCountMine(int?[,] field)
        {
            for (var x = 0; x < field.GetLength(0); x++)
            {
                for (int y = 0; y < field.GetLength(1); y++)
                {
                    if(field.GetValue(x ,y) is null)
                    {
                        field.SetValue(GetCountMineAround(field, x, y), x, y);
                    }
                }
            }

            return field;
        }

        private static int GetCountMineAround(int?[,] field, int x, int y)
        {
            var count = 0;
            count += IsExistMine(field, x, y + 1); // верх
            count += IsExistMine(field, x + 1, y + 1); // верх-право
            count += IsExistMine(field, x + 1, y); // право
            count += IsExistMine(field, x + 1, y - 1); // низ-право
            count += IsExistMine(field, x, y - 1); // низ
            count += IsExistMine(field, x - 1, y - 1); // низ-лево
            count += IsExistMine(field, x - 1, y); // лево
            count += IsExistMine(field, x - 1, y + 1);
            return count;
        }

        private static int IsExistMine(int?[,] field, int x, int y)
        {
            if (x < 0 || y < 0)
            {
                return 0;
            }

            if(x >= field.GetLength(0) || y >= field.GetLength(1))
            {
                return 0;
            }

            var value = field[x, y] is null ? 0 : field[x, y].Value;
            if(value == 10)
            {
                return 1;
            }

            return 0;
        }
    }
}
