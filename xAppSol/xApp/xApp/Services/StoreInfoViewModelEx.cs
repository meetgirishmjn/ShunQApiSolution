using System;
using System.Collections.Generic;
using System.Text;
using xApp.Models;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using xApp.ViewModels;

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
            this.ScanResultCommand = new Command<ZXing.Result>(onScanResult);
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
                this._isScannerOn = value;
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
                this.NotifyPropertyChanged(nameof(BadgeText));
            }
        }
        public bool IsQrNotAnalysing
        {
            get { return !_isQrAnalysing; }
        }

        bool _isAddScanActive = false;
        public bool IsAddScanActive
        {
            get { return _isAddScanActive; }
            set
            {
                this._isAddScanActive = value;
                this.NotifyPropertyChanged();
                this.NotifyPropertyChanged(nameof(IsAddScanNotActive));
            }
        }
        public bool IsAddScanNotActive
        {
            get { return !_isAddScanActive; }
        }

        public Color AddBtnBgColor
        {
            get { return _isLoading ? (Color)App.Current.Resources["Gray-100"] : (Color)App.Current.Resources["Blue"]; }
        }

        public Color ReturnBtnBgColor
        {
            get { return _isLoading ? (Color)App.Current.Resources["Gray-100"] : (Color)App.Current.Resources["Red"]; }
        }

        public string BadgeText { get { return AppViewModel.Instance.CartItemCount.ToString(); } }

        #region "Commands"
        public ICommand OnAddScanBeginCommand { get; set; }
        public ICommand AddScannedCommand { get; set; }
        public ICommand ScanResultCommand { get; set; }
        public ICommand OnRemoveScanBeginCommand { get; set; }
        public ICommand RemoveScannedCommand { get; set; }
        public ICommand OnCancelScanBeginCommand { get; set; }
        
        private void onCancelScanBegin()
        {
            if (this.IsQrAnalysing)
                return;

            this.IsScannerOn = false;
            this.IsAddScanActive = false;
        }
        private  void onScanResult(ZXing.Result result)
        {
            if (IsAddScanActive)
                 AddScannedResult(result);
            else
                RemoveScannedResult(result);
        }
        private void onAddScanBegin()
        {
            try
            {
                this.IsScannerOn = true;
                this.IsAddScanActive = true;
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
                this.IsScannerOn = true;
                this.IsAddScanActive = false;
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

            if (this.IsLoading)
                return;
            
            if (this.IsScannerOff)
                return;

            try
            {
                this.IsQrAnalysing = true;
                this.IsLoading = true;
                var appVm = await this.api.AddToCart(result.Text);
                this.IsQrAnalysing = false;
                this.IsAddScanActive = false;
                this.IsLoading = false;
                this.IsScannerOn = false;

                Device.BeginInvokeOnMainThread(() =>
                {
                    toastr.ShowInfo("Item added to cart");
                });
            }
            catch (Exception ex)
            {
                this.IsLoading = false;
                this.IsQrAnalysing = false;
            }
        }
        private async void RemoveScannedResult(ZXing.Result result)
        {
            if (this.IsQrAnalysing)
                return;

            if (this.IsLoading)
                return;

            if (this.IsScannerOff)
                return;
            try
            {
                this.IsQrAnalysing = true;
                this.IsLoading = true;
                var appVm = await this.api.RemoveFromCart(result.Text);
                this.IsQrAnalysing = false;
                this.IsScannerOn = false;
                this.IsLoading = false;

                Device.BeginInvokeOnMainThread(() =>
                {
                    toastr.ShowWarning("Item removed to cart");
                });
            }
            catch(Exception ex)
            {
                this.IsQrAnalysing = false;
                this.IsLoading = false;
            }
        }

        #endregion "Commands"
    }
}
