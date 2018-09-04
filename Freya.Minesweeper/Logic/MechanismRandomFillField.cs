using Freya.Minesweeper.Logic.Interfaces;
using Freya.Minesweeper.Logic.WayPlacementMine;
using System;

namespace Freya.Minesweeper.Logic
{
    public class MechanismRandomFillField : IMechanismFillingField
    {
        public int?[,] Fill(int numberOfMine, int horisontalNumbersOfCells, int verticalyNumberOfCells)
        {
            var field = new int?[horisontalNumbersOfCells, verticalyNumberOfCells];
            var random = new Random();
            int filled = 0;
            var listMine = new ListMine<CommonPlacementMine>(numberOfMine);
            while (filled < numberOfMine)
            {
                int x = random.Next(0, horisontalNumbersOfCells); // брать где то размеры массива или прокидывать их из свойств
                int y = random.Next(0, verticalyNumberOfCells);
                if(field.GetValue(x, y) is null)    
                {
                    field.SetValue((int)listMine.Next().TypeOfMine, x, y);
                    filled++;
                }
            }

            return field;
        }
    }
}
