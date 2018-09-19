using Freya.Minesweeper.Core;
using Freya.Minesweeper.Core.Mines;
using Freya.Minesweeper.CustomUIElement;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Freya.Minesweeper.Draw
{
    public class Drawer
    {
        public static void Draw(UniformGrid grid, Field field, RoutedEventHandler clickMethod, MouseButtonEventHandler rightClickMethod)
        {
            grid.Children.Clear();
            grid.Rows = field.VerticalyCount;
            grid.Columns = field.HorisontalCount;

            var allCells = field.GetAllCells();
            foreach (var cell in allCells)
            {
                var button = new MineButton()
                {
                    Height = 30,
                    Width = 30,
                    X = cell.X,
                    Y = cell.Y
                };

                if (cell.IsShow)
                {
                    if (cell.Mine is MineBase)
                    {
                        button.Content = "*";
                        button.Background = Brushes.IndianRed;
                    }
                    else
                    {
                        button.Content = cell.CountMineAround == 0 ? "" : cell.CountMineAround.ToString();
                        button.Background = Brushes.Gray;
                    }
                }

                if (cell.Flag is Flag.Flag)
                {
                    button.Content = "!";
                }

                button.Click += clickMethod;
                button.PreviewMouseRightButtonDown += rightClickMethod;
                grid.Children.Add(button);

                Grid.SetRow(button, cell.Y + 1);
                Grid.SetColumn(button, cell.X);
            }
        }
    }
}
