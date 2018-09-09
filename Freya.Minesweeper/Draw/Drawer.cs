using Freya.Minesweeper.Core;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Freya.Minesweeper.Draw
{
    public class Drawer
    {
        public static void Draw(UniformGrid grid, Field field, RoutedEventHandler clickMethod)
        {
            grid.Rows = field.Cells.GetLength(1);
            grid.Columns = field.Cells.GetLength(0);

            for (int x = 0; x < field.Cells.GetLength(0); x++)
            {
                for (int y = 0; y < field.Cells.GetLength(1); y++)
                {
                    var button = new Button()
                    {
                        Height = 30,
                        Width = 30
                    };

                    button.Click += clickMethod;
                    grid.Children.Add(button);

                    Grid.SetRow(button, y + 1);
                    Grid.SetColumn(button, x);
                }
            }
        }
    }
}
