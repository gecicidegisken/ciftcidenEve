﻿using ciftcidenEve.Models;
using ciftcidenEve.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace ciftcidenEve.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IDataStore<Product> DataStore => DependencyService.Get<IDataStore<Product>>();
        public IDataStore<Product> Bag => DependencyService.Get<IDataStore<Product>>();

        bool isBusy = false;
        string btnText = "Giriş Yap";
        public string BtnText
        {

            set
            {
                btnText = value;
                OnPropertyChanged("BtnText");
            }
            get
            {
                return btnText;
            }

        }
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        //deneme
        public event PropertyChangedEventHandler ImagePropertyChanged;
        protected void OnImagePropertyChanged(Image propertyName)
        {
            var changed = ImagePropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName.ToString()));
        }
        #endregion
    }
}
