using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using RandomNeko.ViewModels;
using System.Diagnostics;

namespace RandomNeko.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            InputBox.KeyDown += (sender, e) =>
            {
                if (e.Key == Key.Enter)
                {
                    SendBtn.RaiseEvent(e);
                }
            };
        }
    }
}