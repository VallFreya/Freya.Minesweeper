using Freya.Minesweeper.Core;
using Freya.Minesweeper.CustomUIElement;
using Freya.Minesweeper.Draw;
using Freya.Minesweeper.Logic;
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
            field.Cells[button.X, button.Y].SetShowForTrue();
            Drawer.Draw(mainGrid, field, Click);
        }
    }
}
