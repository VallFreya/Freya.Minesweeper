﻿using Freya.Minesweeper.Core;
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
            for(int x = 0; x < field.HorisontalCount; x++)
            {
                for(int y = 0; y < field.VerticalyCount; y++)
                {
                    field.SetCell(new Cell(x, y));
                }
            }

            var listMine = new ListMine<CommonPlacementMine>(numberOfMine);
            while (filled < numberOfMine)
            {
                int x = random.Next(0, horisontalNumbersOfCells);
                int y = random.Next(0, verticalyNumberOfCells);
                if (field.GetCell(x, y).Mine is null)    
                {
                    field.SetCell(field.GetCell(x, y).SetMine(listMine.Next()));
                    filled++;
                }
            }

            return field;
        }
    }
}
