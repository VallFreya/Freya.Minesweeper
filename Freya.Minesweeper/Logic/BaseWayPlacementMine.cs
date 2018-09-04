using Freya.Minesweeper.Core.Mines;
using System.Collections.Generic;

namespace Freya.Minesweeper.Logic
{
    /// <summary>
    /// Класс описывающий тип мин и процент появления этих мин на поле при генерации поля
    /// </summary>
    public abstract  class BaseWayPlacementMine
    {
        public BaseWayPlacementMine()
        {
        }

        /// <summary>
        /// Метод возвращающий словарь с типом мины и процентом появления его на поле
        /// </summary>
        public abstract Dictionary<MineBase, double> GetTypesMines();
    }
}
