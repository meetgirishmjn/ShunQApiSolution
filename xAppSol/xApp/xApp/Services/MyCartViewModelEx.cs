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
   public partial class MyCartViewModelEx : INotifyPropertyChanged
    {
        ApiService api;
        public ShoppingCart Cart { get; set; }

        private ObservableCollection<CartItemVM> _cartItems;
        public ObservableCollection<CartItemVM> CartItems
        {
            get
            {
                return _cartItems;
            }
            set
            {
                this._cartItems = value;
                this.NotifyPropertyChanged();
            }
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

        public  MyCartViewModelEx()
        {
            this.IsLoading = true;
            this.Cart = new ShoppingCart();
            this.CartItems= new ObservableCollection<CartItemVM>();
         //   this.api = new ApiService();
         //   this.Cart =  api.GetCurrentCart().Result;

            // //  var content = "{\"id\":\"f2af27cf-9925-4b16-bf7f-444590f7d88e\",\"storeId\":1006,\"storeCode\":null,\"cartDeviceId\":null,\"storeName\":\"Metro Cash And Carry\",\"storeImage\":\"https://cdn0storage0shunq0dev.blob.core.windows.net/images/stores/STR-6-Thumb.jpg\",\"storeBannerImage\":\"https://cdn0storage0shunq0dev.blob.core.windows.net/images/stores/STR-6-Banner.jpg\",\"currency\":{\"currency\":\"INR\",\"name\":\"Indian Rupee\",\"symbol\":\"₹\"},\"userId\":0,\"status\":null,\"itemCount\":1,\"items\":[{\"productId\":\"1\",\"productName\":\"Device-1\",\"shortName\":\"\",\"description\":\"Test Product Description\",\"thumbImage\":\"https://cdn0storage0shunq0dev.blob.core.windows.net/images/products/1.jpg\",\"mrp\":246.95,\"discount\":59.0,\"discountText\":\"10% Discount\",\"price\":187.95,\"sortOrder\":1,\"quantity\":1}],\"vouchers\":[],\"lineItemCount\":1,\"totalAmount\":246.95,\"totalItemDiscount\":59.0,\"totalVoucherDiscount\":0.0,\"netAmount\":187.95,\"amountBeforeVoucherDiscount\":187.95,\"userName\":null,\"fullName\":null}";
            ////   this.Cart = Newtonsoft.Json.JsonConvert.DeserializeObject<ShoppingCart>(content);
            //   this.IsLoading = false;
        }

        public async void OnLoad()
        {
            this.api = new ApiService();
            Cart = await api.GetCurrentCart();

            if (Cart == null)
                IsCartEmpty = true;
            else if (Cart.ItemCount == 0)
                IsCartEmpty = true;
            else
                IsCartEmpty = false;

            if (Cart != null)
                this.CartItems = new ObservableCollection<CartItemVM>(Cart.Items);

            this.IsLoading = false;
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
                this.NotifyPropertyChanged(nameof(Title));
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
        public string Title { get { return CartItems.Count==0 ? "My Cart" : "My Cart - (" + Cart.ItemCount + " Item" + (Cart.ItemCount > 1 ? "s" : "") + ")"; } }
        public async void LoadCart()
        {
            var task1 = Task.Delay(2000);
            var task2 = api.GetCurrentCart();


            await Task.WhenAll(task1, task2);
            var cart =task2.Result;

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
