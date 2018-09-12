using System.Windows.Controls;

namespace Freya.Minesweeper.CustomUIElement
{
    public class MineButton : Button
    {
        /// <summary>
        /// Положение кнопки по вертикали
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Положение кнопки по горизонтали
        /// </summary>
        public int Y { get; set; }
    }
}
