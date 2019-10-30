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
    public partial class HomeViewResult : INotifyPropertyChanged
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

        public HomeViewResult()
        {
            this.BannerUrls = new string[] { };
            this.TileSections = new TileSection[] { };
            this.QrScannedCommand = new Command<ZXing.Result>(QrScannedResult);
            this.api =new ApiService();
        }

        public List<ServiceItem> AllServices { get; set; }= new List<ServiceItem>
            {
                new ServiceItem
                {
                    Name = "History",
                    Icon = "\uf1da"
                },
                new ServiceItem
                {
                    Name = "Notification",
                    Icon = "\uf0f3"
                },
                new ServiceItem
                {
                    Name = "Categories",
                    Icon = "\uf5fd"
                },
                new ServiceItem
                {
                    Name = "Reward",
                    Icon = "\uf091"
                },
                new ServiceItem
                {
                    Name = "Review Expenses",
                    Icon = "\uf3d1"
                },
                 new ServiceItem
                {
                    Name = "Offers",
                    Icon = "\uf79c"
                }
            };

        public string BadgeText { get { return this.Cart?.ItemCount > 0 ? this.Cart.ItemCount.ToString() : ""; } }

        public string StartShoppingText { get { return IsQRCodeAnalysing?"QR Scanning ..." :(!this.HasActiveCart ? "START SHOPPING" : "RESUME SHOPPING"); } }

        bool _isQRCodeAnalysing = false;
        public bool IsQRCodeAnalysing { get{ return _isQRCodeAnalysing; } set
            {
                this._isQRCodeAnalysing = value;
                this.NotifyPropertyChanged();
                this.NotifyPropertyChanged(nameof(IsQRCodeNotAnalysing));
                this.NotifyPropertyChanged(nameof(StartShoppingText));
            }
        }
        public bool IsQRCodeNotAnalysing
        {
            get { return !_isQRCodeAnalysing; }
        }

        public ICommand QrScannedCommand { get; set; }
        public Syncfusion.XForms.PopupLayout.SfPopupLayout CartQRCodePopup;

        private async void QrScannedResult(ZXing.Result result)
        {
            if (this.IsQRCodeAnalysing)
                return;

            try
            {
                this.IsQRCodeAnalysing = true;

                var storeInfoVM = await this.api.StartShopping(result.Text);

                ViewModels.AppViewModel.Instance.SetViewModel(storeInfoVM);

                if (storeInfoVM != null)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        App.Current.MainPage = new NavigationPage(new Views.StoreShop.StoreShopPage());
                    });
                    return;
                }
                Device.BeginInvokeOnMainThread( () =>
                {
                    if (CartQRCodePopup != null)
                        CartQRCodePopup.Dismiss();
                    this.IsQRCodeAnalysing = false;
                });
            }
            catch (Exception ex)
            {
                this.IsQRCodeAnalysing = false;
            }
        }

    }


    public partial class HomeViewResult2 : INotifyPropertyChanged
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

        public HomeViewResult2()
        {
            this.BannerUrls = new string[] { };
            this.TileSections = new HomeViewResult.TileSection[] { };
            this.QrScannedCommand = new Command<ZXing.Result>(QrScannedResult);
            this.api = new ApiService();
        }

        public List<ServiceItem> AllServices { get; set; } = new List<ServiceItem>
            {
                new ServiceItem
                {
                    Name = "History",
                    Icon = "\uf1da"
                },
                new ServiceItem
                {
                    Name = "Notification",
                    Icon = "\uf0f3"
                },
                new ServiceItem
                {
                    Name = "Categories",
                    Icon = "\uf5fd"
                },
                new ServiceItem
                {
                    Name = "Reward",
                    Icon = "\uf091"
                },
                new ServiceItem
                {
                    Name = "Review Expenses",
                    Icon = "\uf3d1"
                },
                 new ServiceItem
                {
                    Name = "Offers",
                    Icon = "\uf79c"
                }
            };

        public string BadgeText { get { return this.AppView.HasActiveCart ? this.AppView.CartItemCount.ToString():""; } }

        public string StartShoppingText { get { return IsQRCodeAnalysing ? "QR Scanning ..." : (!this.AppView.HasActiveCart ? "START SHOPPING" : "RESUME SHOPPING"); } }

        bool _isQRCodeAnalysing = false;
        public bool IsQRCodeAnalysing
        {
            get { return _isQRCodeAnalysing; }
            set
            {
                this._isQRCodeAnalysing = value;
                this.NotifyPropertyChanged();
                this.NotifyPropertyChanged(nameof(IsQRCodeNotAnalysing));
                this.NotifyPropertyChanged(nameof(StartShoppingText));
            }
        }
        public bool IsQRCodeNotAnalysing
        {
            get { return !_isQRCodeAnalysing; }
        }

        public ICommand QrScannedCommand { get; set; }
        public Syncfusion.XForms.PopupLayout.SfPopupLayout CartQRCodePopup;

        private async void QrScannedResult(ZXing.Result result)
        {
            if (this.IsQRCodeAnalysing)
                return;

            try
            {
                this.IsQRCodeAnalysing = true;

                var storeInfoVM = await this.api.StartShopping(result.Text);

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
                this.IsQRCodeAnalysing = false;
            }
        }

    }
}
