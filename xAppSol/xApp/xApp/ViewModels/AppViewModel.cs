using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using xApp.Models;

namespace xApp.ViewModels
{

  public  class AppViewModel : INotifyPropertyChanged
    {
        static AppViewModel _apv=new AppViewModel();

        public static AppViewModel Instance { get { return _apv; } }

        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">Property name</param>
        public void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        #region "HasActiveCart"
        private bool _hasActiveCart = false;
        public bool HasActiveCart
        {
            get
            {
                return this._hasActiveCart;
            }
            set
            {
                this._hasActiveCart = value;
                this.NotifyPropertyChanged();
            }
        }
        #endregion "HasActiveCart"

        #region "CartItemCount"
        private int _cartItemCount = 0;
        public int CartItemCount
        {
            get
            {
                return this._cartItemCount;
            }
            set
            {
                this._cartItemCount = value;
                this.NotifyPropertyChanged();
            }
        }
        #endregion "CartItemCount"

        #region "CurrentUser"
        private User _currentUser = null;
        public User CurrentUser
        {
            get
            {
                return this._currentUser;
            }
            set
            {
                this._currentUser = value;
                this.NotifyPropertyChanged();
            }
        }
        #endregion "CurrentUser"

        private Dictionary<string, object> _cache = new Dictionary<string, object>();

        public T GetViewModel<T>() where T : class
        {
            var tname = typeof(T).Name;
            if (_cache.ContainsKey(tname))
                return (T)_cache[tname];
            else
                return null;
        }

        public void SetViewModel<T>(T vm)
        {
            var tname = typeof(T).Name;
            if (_cache.ContainsKey(tname))
                _cache[tname] = vm;
            else
                _cache.Add(tname, vm);
        }
    }
}
