using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xApp.Services
{
   public partial class MyCartViewModelEx : INotifyPropertyChanged
    {
        ApiService api;
        public ShoppingCart Cart { get; set; }

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

        public MyCartViewModelEx()
        {
            this.IsLoading = true;
            this.api = new ApiService();
            Task.Run(LoadCart);
        }

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
                this.NotifyPropertyChanged(nameof(IsCartReady));
            }
        }

        public bool IsNotLoading
        {
            get { return !_isLoading; }
        }
        #endregion "IsLoading"

        #region "IsCartEmpty"
        bool _isCartEmpty = false;
        public bool IsCartEmpty
        {
            get { return _isCartEmpty; }
            set
            {
                this._isCartEmpty = value;
                this.NotifyPropertyChanged();
                this.NotifyPropertyChanged(nameof(IsCartNotEmpty));
                this.NotifyPropertyChanged(nameof(IsCartReady));
                this.NotifyPropertyChanged(nameof(Title));

            }
        }

        public bool IsCartNotEmpty
        {
            get { return !_isCartEmpty; }
        }

        #endregion "IsCartEmpty"

        public bool IsCartReady { get { return this.IsNotLoading && Cart != null && IsCartNotEmpty; } }
        public string Title { get { return Cart == null ? "My Cart" : "My Cart - (" + Cart.ItemCount + " Item" + (Cart.ItemCount > 1 ? "s" : "") + ")"; } }
        public async void LoadCart()
        {
           await Task.Delay(1000);

            var cart = await api.GetCurrentCart();

            Device.BeginInvokeOnMainThread(  () =>
            {
                try
                {
                    this.Cart = cart;
                    if (Cart == null)
                        IsCartEmpty = true;
                    else if (Cart.ItemCount == 0)
                        IsCartEmpty = true;

                    this.IsLoading = false;
                }catch(Exception ex)
                {

                }
            });
        }
    }
}
