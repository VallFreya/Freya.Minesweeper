namespace Freya.Minesweeper.Core.Mines
{
    public abstract class MineBase
    {
        public MineBase()
        {
        }

        public MineBase(TypeOfMine typeOfMine)
        {
            TypeOfMine = typeOfMine;
        }

        /// <summary>
        /// Тип тип мины
        /// </summary>
        public TypeOfMine TypeOfMine { get; private set; } = TypeOfMine.Common;
    }
}
