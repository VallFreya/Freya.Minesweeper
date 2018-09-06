using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Freya.Minesweeper.Draw
{
    public class Drawer
    {
        public void Draw(Grid grid, int?[,] field)
        {
            for (int i = 0; i < field.GetLength(1); i++)
            {
                grid.RowDefinitions.Add(new RowDefinition()
                {
                    Height = GridLength.Auto,
                });
            }

            for (int j = 0; j < field.GetLength(1); j++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition()
                {
                    Width = GridLength.Auto,
                });
            }

            for (int x = 0; x < field.GetLength(0); x++)
            {
                for (int y = 0; y < field.GetLength(1); y++)
                {
                    var button = new Button()
                    {
                        Height = 50,
                        Width = 50,
                        Content = $"{field.GetValue(x, y)}"
                    };

                    grid.Children.Add(button);

                    Grid.SetRow(button, y);
                    Grid.SetColumn(button, x);
                }
            }
        }
    }
}
