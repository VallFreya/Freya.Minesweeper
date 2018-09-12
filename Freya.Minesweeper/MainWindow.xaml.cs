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
            var listForOpen = new List<Cell>();
            listForOpen.Add(field.Cells[button.X, button.Y]);

            if(field.Cells[button.X, button.Y].Mine is MineBase)
            {
                MessageBox.Show("GameOver");
            }

            while (listForOpen.Count != 0)
            {
                var cell = listForOpen.First();
                int x = cell.X;
                int y = cell.Y;
                if(cell.CountMineAround == 0 || cell.Mine is MineBase)
                {
                    listForOpen.AddRange(Field.GetAllCellsAround(field, cell)
                        .Where(c => c.IsShow == false &&
                                    c.Mine is null));
                }
                field.Cells[x, y].SetShowForTrue();
                listForOpen.Remove(field.Cells[x, y]);
            }
            
            Drawer.Draw(mainGrid, field, Click);
        }
    }
}
