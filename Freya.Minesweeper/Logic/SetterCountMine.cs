using Freya.Minesweeper.Core;
using Freya.Minesweeper.Core.Mines;

namespace Freya.Minesweeper.Logic
{
    /// <summary>
    /// Класс, устанавливающий количество мин вокруг ячейки
    /// </summary>
    public class SetterCountMine
    {
        public static Field Set(Field field)
        {
            for (var x = 0; x < field.Cells.GetLength(0); x++)
            {
                for (int y = 0; y < field.Cells.GetLength(1); y++)
                {
                    if (field.Cells.GetValue(x, y) is null)
                    {
                        field.Cells[x, y] = new Cell(GetCountMineAround(field, x, y), x, y);
                    }
                }
            }

            return field;
        }

        private static int GetCountMineAround(Field field, int x, int y)
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

        private static int IsExistMine(Field field, int x, int y)
        {
            if (x < 0 || y < 0)
            {
                return 0;
            }

            if (x >= field.Cells.GetLength(0) || y >= field.Cells.GetLength(1))
            {
                return 0;
            }
            
            if (field.Cells[x, y]?.Mine is MineBase)
            {
                return 1;
            }

            return 0;
        }
    }
}
