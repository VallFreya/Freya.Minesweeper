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
            Drawer.Draw(mainGrid, field, Click);
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Привет");
        }
    }
}
