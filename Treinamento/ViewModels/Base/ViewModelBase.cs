using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Treinamento.Resources;
using Xamarin.Forms;

namespace Treinamento.ViewModels.Base
{
    public class ViewModelBase : ExtendedBindableObject
    {
        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }

        protected bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        protected string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value, Action onChanged = null, [CallerMemberName]string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        public bool StartLoading()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                MessagingCenter.Send(this, MessageKeys.StartLoading);
                return IsBusy;
            }

            return false;
        }

        public bool StopLoading()
        {
            IsBusy = false;
            MessagingCenter.Send(this, MessageKeys.StopLoading);
            return IsBusy;
        }
        
        private bool isBusy = false;

        private string title = string.Empty;
    }
}
