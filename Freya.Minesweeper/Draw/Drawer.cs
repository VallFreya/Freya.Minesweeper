﻿using Freya.Minesweeper.Core;
using Freya.Minesweeper.Core.Mines;
using Freya.Minesweeper.CustomUIElement;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Freya.Minesweeper.Draw
{
    public class Drawer
    {
        public static void Draw(UniformGrid grid, Field field, RoutedEventHandler clickMethod)
        {
            grid.Children.Clear();
            grid.Rows = field.Cells.GetLength(1);
            grid.Columns = field.Cells.GetLength(0);

            for (int x = 0; x < field.Cells.GetLength(0); x++)
            {
                for (int y = 0; y < field.Cells.GetLength(1); y++)
                {
                    var cell = field.Cells[x, y];
                    var button = new MineButton()
                    {
                        Height = 30,
                        Width = 30,
                        X = x,
                        Y = y
                    };

                    if(cell.IsShow)
                    {
                        if(cell.Mine is MineBase)
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

                    button.Click += clickMethod;
                    grid.Children.Add(button);

                    Grid.SetRow(button, y + 1);
                    Grid.SetColumn(button, x);
                }
            }
        }
    }
}
