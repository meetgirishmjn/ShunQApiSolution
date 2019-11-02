using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xApp.Services
{
  public partial  class PaySuccessViewModelEx : INotifyPropertyChanged
    {
        ApiService api;

        public PaySuccessViewModelEx()
        {
            this.IsLoading = true;
            this.IsSuccess = false;
        }

        #region "PropertyChanged"
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">Property name</param>
        public void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion "PropertyChanged"

        #region "IsLoading"
        bool _isLoading = false;
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                this._isLoading = value;
                this.NotifyPropertyChanged();
                this.NotifyPropertyChanged(nameof(IsNotLoading));
            }
        }

        public bool IsNotLoading
        {
            get { return !_isLoading; }
        }
        #endregion "IsLoading"

        string _checkoutCode = string.Empty;
        public string CheckoutCode
        {
            get { return _checkoutCode; }
            set
            {
                this._checkoutCode = value;
                this.NotifyPropertyChanged();
            }
        }
        string _errorMessage = string.Empty;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                this._errorMessage = value;
                this.NotifyPropertyChanged();
            }
        }

        #region "IsSuccess"
        bool _isSuccess = false;
        public bool IsSuccess
        {
            get { return _isSuccess; }
            set
            {
                this._isSuccess = value;
                this.NotifyPropertyChanged();
                this.NotifyPropertyChanged(nameof(IsNotSuccess));
            }
        }

        public bool IsNotSuccess
        {
            get { return !_isSuccess; }
        }
        #endregion "IsSuccess"

        public async void OnLoad()
        {
            this.api = new ApiService();
            var result = await api.GetPaySuccessInfo();

            if (result != null)
            {
                this.IsSuccess = result.IsSuccess;
                this.ErrorMessage = result.ErrorMessage;
                this.CheckoutCode = result.CheckoutCode;
            }
            else
            {
                this.IsSuccess = false;
                this.ErrorMessage = "Could not create Self-Checkout code. Try again.";
            }
            this.IsLoading = false;
        }
    }
}
