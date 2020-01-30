using Treinamento.Resources;
using Treinamento.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Treinamento.Views.Templates
{
    [ContentProperty("Child")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainTemplate : ContentPage
    {
        public MainTemplate()
        {
            InitializeComponent();
        }

        public View Body
        {
            get => bodyContent.Content;
            set => bodyContent.Content = value;
        }

        public View Header
        {
            get => headerContent.Content;
            set => headerContent.Content = value;
        }

        public View Footer
        {
            get => footerContent.Content;
            set => footerContent.Content = value;
        }

        public static BindableProperty CopyrightProperty = BindableProperty.Create(
        nameof(Copyright), typeof(string), typeof(MainTemplate), string.Empty, BindingMode.TwoWay);

        public string Copyright
        {
            get => GetValue(CopyrightProperty).ToString();
            set => SetValue(CopyrightProperty, value);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            InitializeMessagingCenter();
        }

        private void InitializeMessagingCenter()
        {
            if (BindingContext is ViewModelBase viewModelBase)
            {
                MessagingCenter.Subscribe<ViewModelBase>(viewModelBase, MessageKeys.StartLoading, (result) =>
                {
                    IsBusy = true;
                });
                MessagingCenter.Subscribe<ViewModelBase>(viewModelBase, MessageKeys.StopLoading, (result) =>
                {
                    IsBusy = false;
                });
                MessagingCenter.Send<ViewModelBase>(viewModelBase, MessageKeys.StopLoading);
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            RemoveMessagingCenter();
        }

        private void RemoveMessagingCenter()
        {
            if (BindingContext is ViewModelBase viewModelBase)
            {
                MessagingCenter.Unsubscribe<ViewModelBase>(viewModelBase, MessageKeys.StartLoading);
                MessagingCenter.Unsubscribe<ViewModelBase>(viewModelBase, MessageKeys.StopLoading);
            }
        }
    }
}