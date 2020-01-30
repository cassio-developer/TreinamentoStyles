using System.Threading.Tasks;
using System.Windows.Input;
using Treinamento.ViewModels.Base;
using Treinamento.Views;
using Xamarin.Forms;

namespace Treinamento.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand NextPageCommand => new Command(async () => {
            StartLoading();
            await Task.Delay(1000);
            await Application.Current.MainPage.Navigation.PushAsync(new AnotherView());
            StopLoading();
        });
    }
}
