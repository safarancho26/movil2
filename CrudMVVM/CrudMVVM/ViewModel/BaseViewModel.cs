﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace CrudMVVM.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private bool _isLoading { get; set; }
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                if (value != _isLoading)
                {
                    _isLoading = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
