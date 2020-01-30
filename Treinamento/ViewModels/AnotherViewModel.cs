using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Treinamento.ViewModels.Base;
using Treinamento.Views;
using Xamarin.Forms;

namespace Treinamento.ViewModels
{
    public class AnotherViewModel : ViewModelBase
    {
        public ICommand PreviosPageCommand => new Command(async () => {
            StartLoading();
            await Task.Delay(1000);
            await Application.Current.MainPage.Navigation.PopAsync();
            StopLoading();
        });
        public ICommand RemoveLetterCommand => new Command(async (value) => {
            StartLoading();
            await Task.Delay(500);
            Alphabet.Remove(value.ToString());
            StopLoading();
        });

        public ICommand NextPageCommand => new Command(async () => {
            StartLoading();
            await Task.Delay(1000);
            await Application.Current.MainPage.Navigation.PushAsync(new OtherView());
            StopLoading();
        });

        public ObservableCollection<string> Alphabet { get; set; }

        public AnotherViewModel()
        {
            Alphabet = new ObservableCollection<string> {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "X", "Z"};
        }
    }
}
