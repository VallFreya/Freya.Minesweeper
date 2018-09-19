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
            var allCells = field.GetAllCells();
            foreach (var cell in allCells)
            {
                if(cell.Mine is null)
                {
                    cell.SetCountMineAround(GetCountMineAround(field, cell));
                }
            }

            return field;
        }

        private static int GetCountMineAround(Field field, Cell cell)
        {
            var minesAround = field.GetAllCellsAround(cell);
            var count = 0;
            foreach (var mine in minesAround)
            {
                count = IsExistMine(field, mine) ? ++count : count;
            }
            
            return count;
        }

        private static bool IsExistMine(Field field, Cell cell)
        {
            if (field.IsOutside(cell))
            {
                return false;
            }
            
            if (cell.Mine is MineBase)
            {
                return true;
            }

            return false;
        }
    }
}
