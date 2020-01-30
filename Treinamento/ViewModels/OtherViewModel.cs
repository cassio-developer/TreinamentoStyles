using System.Threading.Tasks;
using System.Windows.Input;
using Treinamento.ViewModels.Base;
using Xamarin.Forms;

namespace Treinamento.ViewModels
{
    public class OtherViewModel : ViewModelBase
    {
        public ICommand PreviosPageCommand => new Command(async () => {
            StartLoading();
            await Task.Delay(1000);
            await Application.Current.MainPage.Navigation.PopAsync();
            StopLoading();
        });
    }
}
