using System;
using System.Collections.Generic;
using System.Text;
using xApp.Models;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace xApp.Services
{
    public partial class StoreInfoViewModel : INotifyPropertyChanged
    {
        ApiService api;
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

        public StoreInfoViewModel()
        {
            this.api = new ApiService();
            this.AddScannedCommand = new Command<ZXing.Result>(AddScannedResult);
            this.RemoveScannedCommand = new Command<ZXing.Result>(RemoveScannedResult);

        }

        bool _isLoading = false;
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                this._isLoading = value;
                this.NotifyPropertyChanged();
                this.NotifyPropertyChanged(nameof(IsNotLoading));
                this.NotifyPropertyChanged(nameof(AddBtnBgColor));
                this.NotifyPropertyChanged(nameof(ReturnBtnBgColor));
            }
        }

        public bool IsNotLoading
        {
            get { return !_isLoading; }
        }

        bool _isScannerOn = false;
        public bool IsScannerOn
        {
            get { return _isScannerOn; }
            set
            {
                this._isLoading = value;
                this.NotifyPropertyChanged();
                this.NotifyPropertyChanged(nameof(IsScannerOff));
            }
        }
        public bool IsScannerOff
        {
            get { return !_isScannerOn; }
        }

        bool _isQrAnalysing = false;
        public bool IsQrAnalysing
        {
            get { return _isQrAnalysing; }
            set
            {
                this._isQrAnalysing = value;
                this.NotifyPropertyChanged();
                this.NotifyPropertyChanged(nameof(IsQrNotAnalysing));
            }
        }
        public bool IsQrNotAnalysing
        {
            get { return !_isQrAnalysing; }
        }

        public Color AddBtnBgColor
        {
            get { return _isLoading ? (Color)App.Current.Resources["Gray-100"] : (Color)App.Current.Resources["Blue"]; }
        }

        public Color ReturnBtnBgColor
        {
            get { return _isLoading ? (Color)App.Current.Resources["Gray-100"] : (Color)App.Current.Resources["Red"]; }
        }


        #region "Commands"
        public ICommand AddScannedCommand { get; set; }
        public ICommand RemoveScannedCommand { get; set; }

        private async void AddScannedResult(ZXing.Result result)
        {
            if (this.IsQrAnalysing)
                return;

            try
            {
                this.IsQrAnalysing = true;

                var storeInfoVM = await this.api.AddToCart(result.Text);

                ViewModels.AppViewModel.Instance.SetViewModel(storeInfoVM);

                if (storeInfoVM != null)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        App.Current.MainPage = new NavigationPage(new Views.StoreShop.StoreShopPage());
                    });
                    return;
                }
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (CartQRCodePopup != null)
                        CartQRCodePopup.Dismiss();
                    this.IsQRCodeAnalysing = false;
                });
            }
            catch (Exception ex)
            {
                this.IsQrAnalysing = false;
            }
        }
        private async void RemoveScannedResult(ZXing.Result result)
        {
            try
            {

            }catch(Exception ex)
            {

            }
        }

        #endregion "Commands"
    }
}
