using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Smart_Shop_List.ViewModels
{
    public class ListViewModel : BaseViewModel
    {
        public ListViewModel()
        {
            Title = "Liste";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://xamarin.com"));
        }

        public ICommand OpenWebCommand { get; }
    }
}