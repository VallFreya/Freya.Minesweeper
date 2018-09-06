using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Freya.Minesweeper.Draw
{
    public class Drawer
    {
        public void Draw(UniformGrid grid, int?[,] field)
        {
            grid.Rows = field.GetLength(1);
            grid.Columns = field.GetLength(0);

            for (int x = 0; x < field.GetLength(0); x++)
            {
                for (int y = 0; y < field.GetLength(1); y++)
                {
                    var button = new Button()
                    {
                        Height = 30,
                        Width = 30,
                        Content = $"{field.GetValue(x, y)}"
                    };

                    grid.Children.Add(button);

                    Grid.SetRow(button, y + 1);
                    Grid.SetColumn(button, x);
                }
            }
        }
    }
}
