using Treinamento.ViewModels;
using Treinamento.Views.Templates;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;

namespace Treinamento.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OtherView : MainTemplate
    {
        public OtherView()
        {
            InitializeComponent();
            BindingContext = new AnotherViewModel();
        }
    }
}