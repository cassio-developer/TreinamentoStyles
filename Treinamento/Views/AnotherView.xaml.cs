using System.Threading.Tasks;
using Treinamento.ViewModels;
using Treinamento.Views.Templates;
using Xamarin.Forms.Xaml;

namespace Treinamento.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnotherView : MainTemplate
    {
        public AnotherView()
        {
            InitializeComponent();
            BindingContext = new AnotherViewModel();
        }
    }
}