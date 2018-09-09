using Freya.Minesweeper.Core;
using Freya.Minesweeper.Logic.Interfaces;
using Freya.Minesweeper.Logic.WayPlacementMine;
using System;

namespace Freya.Minesweeper.Logic
{
    public class MechanismRandomFillField : IMechanismFillingField
    {
        public Field Fill(int numberOfMine, int horisontalNumbersOfCells, int verticalyNumberOfCells)
        {
            var field = new Field(horisontalNumbersOfCells, verticalyNumberOfCells);
            var random = new Random();
            int filled = 0;
            var listMine = new ListMine<CommonPlacementMine>(numberOfMine);
            while (filled < numberOfMine)
            {
                int x = random.Next(0, horisontalNumbersOfCells);
                int y = random.Next(0, verticalyNumberOfCells);
                var q = field.Cells.GetValue(x, y);
                if (field.Cells.GetValue(x, y) is null)    
                {
                    field.Cells[x, y] = new Cell(listMine.Next(), x, y);
                    filled++;
                }
            }

            return field;
        }
    }
}
