using Freya.Minesweeper.Core;
using Freya.Minesweeper.Core.Mines;
using Freya.Minesweeper.CustomUIElement;
using Freya.Minesweeper.Draw;
using Freya.Minesweeper.Logic;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Freya.Minesweeper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var field = CreatorField.Create();
            Resources.Add("field", field);
            Drawer.Draw(mainGrid, field, Click);
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            var button = sender as MineButton;
            var field = TryFindResource("field") as Field;
            
            if (field.Cells[button.X, button.Y].Mine is MineBase)
            {
                field.ShowAllMines();
                Drawer.Draw(mainGrid, field, Click);
                MessageBoxResult messageBox = MessageBox.Show("Игра окончена. Начать сначала? Нет - выйти из игры", "Конец игры", MessageBoxButton.YesNo);
                switch (messageBox)
                {
                    case MessageBoxResult.Yes:
                        field = CreatorField.Create();
                        Resources.Remove("field");
                        Resources.Add("field", field);
                        Drawer.Draw(mainGrid, field, Click);
                        return;
                    case MessageBoxResult.No:
                        Close();
                        return;
                }
            }

            var listForOpen = new List<Cell>
            {
                field.Cells[button.X, button.Y]
            };

            while (listForOpen.Count != 0)
            {
                var cell = listForOpen.First();
                int x = cell.X;
                int y = cell.Y;
                if(cell.CountMineAround == 0 || cell.Mine is MineBase)
                {
                    listForOpen.AddRange(field.GetAllCellsAround(cell)
                        .Where(c => c.IsShow == false &&
                                    c.Mine is null));
                }

                field.Cells[x, y].Show();
                listForOpen.Remove(field.Cells[x, y]);
            }
            
            Drawer.Draw(mainGrid, field, Click);
        }
    }
}
