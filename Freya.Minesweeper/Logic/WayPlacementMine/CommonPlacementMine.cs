using System.Collections.Generic;
using Freya.Minesweeper.Core.Mines;

namespace Freya.Minesweeper.Logic.WayPlacementMine
{
    public class CommonPlacementMine : BaseWayPlacementMine
    {
        public override Dictionary<MineBase, double> GetTypesMines()
        {
            return new Dictionary<MineBase, double>
            {
                { new CommonMine(), 1.0 }
            };
        }
    }
}
