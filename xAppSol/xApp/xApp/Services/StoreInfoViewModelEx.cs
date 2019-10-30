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
        IToastr toastr;
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
            this.OnAddScanBeginCommand = new Command(onAddScanBegin);
            this.OnCancelScanBeginCommand = new Command(onCancelScanBegin);
            this.OnRemoveScanBeginCommand = new Command(onRemoveScanBegin);
            toastr = DependencyService.Get<IToastr>();
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
        public ICommand OnAddScanBeginCommand { get; set; }
        public ICommand AddScannedCommand { get; set; }
        public ICommand OnRemoveScanBeginCommand { get; set; }
        public ICommand RemoveScannedCommand { get; set; }
        public ICommand OnCancelScanBeginCommand { get; set; }
        
        private void onCancelScanBegin()
        {
            if (this.IsQrAnalysing)
                return;

            this.IsScannerOn = false;
        }

        private void onAddScanBegin()
        {
            try
            {
                this.IsScannerOn = true;
            }
            catch (Exception ex)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    toastr.ShowError(ex.Message);
                });
            }
        }

        private void onRemoveScanBegin()
        {
            try
            {
                this.IsScannerOn = false;
            }
            catch (Exception ex)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    toastr.ShowError(ex.Message);
                });
            }
        }
        private async void AddScannedResult(ZXing.Result result)
        {
            if (this.IsQrAnalysing)
                return;

            try
            {
                this.IsQrAnalysing = true;

                var appVm = await this.api.AddToCart(result.Text);
                this.IsQrAnalysing = false;
            }
            catch (Exception ex)
            {
                this.IsQrAnalysing = false;
            }
        }
        private async void RemoveScannedResult(ZXing.Result result)
        {
            if (this.IsQrAnalysing)
                return;

            try
            {
                this.IsQrAnalysing = true;
                var appVm = await this.api.RemoveFromCart(result.Text);
                this.IsQrAnalysing = false;
            }
            catch(Exception ex)
            {
                this.IsQrAnalysing = false;
            }
        }

        #endregion "Commands"
    }
}
