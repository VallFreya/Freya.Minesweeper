using Freya.Minesweeper.Core;
using Freya.Minesweeper.Core.Mines;
using Freya.Minesweeper.CustomUIElement;
using Freya.Minesweeper.Draw;
using Freya.Minesweeper.Logic;
using System;
using System.Windows;
using System.Windows.Threading;

namespace Freya.Minesweeper
{
    public partial class MainWindow : Window
    {
        private int timeTicks = 0;
        private DispatcherTimer Timer;
        public MainWindow()
        {
            InitializeComponent();
            Timer = new DispatcherTimer();
            Timer.Tick += new EventHandler(TimerTick);
            Timer.Interval = new TimeSpan(0, 0, 1);
            Run();
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            var button = sender as MineButton;
            var field = TryFindResource("field") as Field;

            Timer.Start();

            if (field.GetCell(button.X, button.Y).Flag is Flag.Flag)
            {
                return;
            }

            if (field.GetCell(button.X, button.Y).Mine is MineBase)
            {
                field.ShowAllMines();
                Drawer.Draw(mainGrid, field, Click, RightClick);
                OpenDialog("Конец игры", "Игра окончена. Начать сначала? Нет - выйти из игры");
                return;
            }
            
            field.ShowAllEmptyCells(button);

            if (field.IsWin())
            {
                OpenDialog("Победа", "Победа. Начать сначала? Нет - выйти из игры");
                return;
            }

            Drawer.Draw(mainGrid, field, Click, RightClick);
        }

        public void RightClick(object sender, RoutedEventArgs e)
        {
            var button = sender as MineButton;
            var field = TryFindResource("field") as Field;

            Timer.Start();

            if (field.IsWin())
            {
                OpenDialog("Победа", "Победа. Начать сначала? Нет - выйти из игры");
                return;
            }

            var cell = field.GetCell(button.X, button.Y);
            if(cell.Flag is Flag.Flag)
            {
                cell.SetEmptyFlag();
            }
            else
            {
                cell.SetFlag();
            }

            CountMine.Content = field.GetNotSetFlagMines();
            Drawer.Draw(mainGrid, field, Click, RightClick);
        }

        private void Run()
        {
            var field = CreatorField.Create();
            Resources.Remove("field");
            Resources.Add("field", field);
            Drawer.Draw(mainGrid, field, Click, RightClick);
            timeTicks = 0;
            LabelTimer.Content = timeTicks;
            CountMine.Content = field.GetNotSetFlagMines();
        }

        private void OpenDialog(string title, string text)
        {
            Timer.Stop();
            MessageBoxResult messageBox = MessageBox.Show(text, title, MessageBoxButton.YesNo);
            switch (messageBox)
            {
                case MessageBoxResult.Yes:
                    Run();
                    return;
                case MessageBoxResult.No:
                    Close();
                    return;
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            LabelTimer.Content = ++timeTicks;
        }
    }
}
