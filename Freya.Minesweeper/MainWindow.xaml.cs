using Freya.Minesweeper.Core;
using Freya.Minesweeper.Core.Mines;
using Freya.Minesweeper.CustomUIElement;
using Freya.Minesweeper.Draw;
using Freya.Minesweeper.Logic;
using System.Windows;

namespace Freya.Minesweeper
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var field = CreatorField.Create();
            Resources.Add("field", field);
            Drawer.Draw(mainGrid, field, Click, RightClick);
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            var button = sender as MineButton;
            var field = TryFindResource("field") as Field;
            if(field.GetCell(button.X, button.Y).Flag is Flag.Flag)
            {
                return;
            }

            if (field.GetCell(button.X, button.Y).Mine is MineBase)
            {
                field.ShowAllMines();
                Drawer.Draw(mainGrid, field, Click, RightClick);
                MessageBoxResult messageBox = MessageBox.Show("Игра окончена. Начать сначала? Нет - выйти из игры", "Конец игры", MessageBoxButton.YesNo);
                switch (messageBox)
                {
                    case MessageBoxResult.Yes:
                        field = CreatorField.Create();
                        Resources.Remove("field");
                        Resources.Add("field", field);
                        Drawer.Draw(mainGrid, field, Click, RightClick);
                        return;
                    case MessageBoxResult.No:
                        Close();
                        return;
                }
            }

            if (field.IsWin())
            {
                MessageBoxResult messageBox = MessageBox.Show("Победа. Начать сначала? Нет - выйти из игры", "Победа", MessageBoxButton.YesNo);
                switch (messageBox)
                {
                    case MessageBoxResult.Yes:
                        field = CreatorField.Create();
                        Resources.Remove("field");
                        Resources.Add("field", field);
                        Drawer.Draw(mainGrid, field, Click, RightClick);
                        return;
                    case MessageBoxResult.No:
                        Close();
                        return;
                }
            }

            field.ShowAllEmptyCells(button);
            Drawer.Draw(mainGrid, field, Click, RightClick);
        }

        public void RightClick(object sender, RoutedEventArgs e)
        {
            var button = sender as MineButton;
            var field = TryFindResource("field") as Field;
            var cell = field.GetCell(button.X, button.Y);
            if(cell.Flag is Flag.Flag)
            {
                cell.SetEmptyFlag();
            }
            else
            {
                cell.SetFlag();
            }

            Drawer.Draw(mainGrid, field, Click, RightClick);
        }
    }
}
