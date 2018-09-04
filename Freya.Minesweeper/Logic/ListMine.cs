using Freya.Minesweeper.Core.Mines;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Freya.Minesweeper.Logic
{
    /// <summary>
    /// Интерфейс для описания метода управления типом мин на игровом поле
    /// </summary>
    public class ListMine<T> where T : BaseWayPlacementMine, new()
    {
        public ListMine(int countMine)
        {
            CreateListMines(countMine);
        }

        private List<MineBase> Mines = new List<MineBase>();

        private List<MineBase>.Enumerator Enumerator;

        /// <summary>
        /// Получить следующую мину
        /// </summary>
        /// <returns></returns>
        public MineBase Next()
        {
            if (Enumerator.MoveNext())
            {
                return Enumerator.Current;
            }

            throw new IndexOutOfRangeException();
        }

        private void CreateListMines(int countMine)
        {
            var placementMines = new T().GetTypesMines();
            foreach(var placementMine in placementMines)
            {
                var count = (int)Math.Truncate(placementMine.Value * countMine);
                Mines.AddRange(Enumerable.Range(0, count).Select(x => placementMine.Key));
            }

            Enumerator = Mines.GetEnumerator();
        }
    }
}
