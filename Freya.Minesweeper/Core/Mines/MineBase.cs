namespace Freya.Minesweeper.Core.Mines
{
    public abstract class MineBase
    {
        public MineBase()
        {
        }

        public MineBase(TypesOfMines typeOfMine)
        {
            TypeOfMine = typeOfMine;
        }

        /// <summary>
        /// Тип тип мины
        /// </summary>
        public TypesOfMines TypeOfMine { get; private set; } = TypesOfMines.Common;
    }
}
