using Avalonia.Layout;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Text;

namespace RandomNeko.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private string _userInput = string.Empty;
        private string[] dots = { "！", "？", "。", "...", "，" };
        public string UserInput { get => _userInput; set { SetProperty(ref _userInput, value); } }
        
        public ObservableCollection<ConverMessage> ConverMessages { get; set; }

        public MainWindowViewModel()
        {
            ConverMessages = new ObservableCollection<ConverMessage>();

            ConverMessages.Add(new ConverMessage(true, "test"));
        }

        [RelayCommand]
        private void SendInput()
        {
            if (UserInput != "")
            {
                AddMes(UserInput);
            }
            
        }

        public void AddMes(string mes)
        {
            Random random= new();
            ConverMessages.Add(new ConverMessage(true, mes));

            int p = random.Next(1, 3);
            StringBuilder nekoMesSb = new();
            for (int i = 1; i <= p; i++)
            {
                int dotIndex = i == p ? random.Next(0, dots.Length - 1) : random.Next(0, dots.Length);
                int niaNum = random.Next(1, 9);

                nekoMesSb.Append(new string('喵', niaNum));
                nekoMesSb.Append(dots[dotIndex]);
            }

            ConverMessages.Add(new ConverMessage(false, nekoMesSb.ToString()));
        }
    }

    public class ConverMessage
    {
        public bool IsUser { get; set; }

        public HorizontalAlignment Ali
        {
            get
            {
                if (IsUser) return HorizontalAlignment.Right;
                else return HorizontalAlignment.Left;
            }
        }
        public string Message { get; set; } = string.Empty;

        public ConverMessage(bool isUser, string mes)
        {
            IsUser = isUser;
            Message = mes;
        }
    }
}