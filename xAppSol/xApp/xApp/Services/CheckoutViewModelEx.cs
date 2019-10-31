using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
namespace xApp.Services
{
  public partial class CheckoutViewModelEx : INotifyPropertyChanged
    {
        private ObservableCollection<CheckoutViewModel.LineItem> _lineItems;
        public ObservableCollection<CheckoutViewModel.LineItem> LineItems
        {
            get
            {
                return _lineItems;
            }
            set
            {
                this._lineItems = value;
                this.NotifyPropertyChanged();
            }
        }


        public ObservableCollection<string> _valMessages;
        public ObservableCollection<string> ValidationMessages
        {
            get
            {
                return _valMessages;
            }
            set
            {
                this._valMessages = value;
                this.NotifyPropertyChanged();
            }
        }

        public ObservableCollection<CheckoutViewModel.VoucherItem> _vouchers;
        public ObservableCollection<CheckoutViewModel.VoucherItem> Vouchers
        {
            get
            {
                return _vouchers;
            }
            set
            {
                this._vouchers = value;
                this.NotifyPropertyChanged();
            }
        }

        public ICommand ItemTapCommand { get; set; }

        public CheckoutViewModelEx()
        {
            this.LineItems = new ObservableCollection<CheckoutViewModel.LineItem>();
            this.IsLoading = true;
        }

        public CheckoutViewModel VM { get; set; }

        //   Icon = "\uf1da"
        public string CartHeaderIcon  { get; set; }
        public Color CartHeaderIconColor  { get; set; }
        public string CartHeaderTitle { get; set; }
        public string ValidationCaption { get; set; }
        public Color CartHeaderBgColor { get; set; }
        public bool IsVoucherApplied { get; set; }
        public bool IsNoVoucherApplied { get { return !IsVoucherApplied; }  }

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
                this.NotifyPropertyChanged(nameof(CartHeaderIcon));
                this.NotifyPropertyChanged(nameof(CartHeaderIconColor));
                this.NotifyPropertyChanged(nameof(CartHeaderTitle));
                this.NotifyPropertyChanged(nameof(CartHeaderBgColor));
                this.NotifyPropertyChanged(nameof(ValidationCaption));
                this.NotifyPropertyChanged(nameof(IsVoucherApplied));
                this.NotifyPropertyChanged(nameof(IsNoVoucherApplied));
            }
        }


        public bool IsNotLoading
        {
            get { return !_isLoading; }
        }
        #endregion "IsLoading"

        #region "IsCartValid"
        bool _isCartValid = false;
        public bool IsCartValid
        {
            get { return _isCartValid; }
            set
            {
                this._isCartValid = value;
                this.NotifyPropertyChanged();
                this.NotifyPropertyChanged(nameof(IsCartNotValid));
            }
        }


        public bool IsCartNotValid
        {
            get { return !_isCartValid; }
        }
        #endregion "IsCartValid"
        public async void OnLoad()
        {
            var api = new ApiService();
           
            this.VM = await api.GetCheckoutView();

            if (this.VM != null)
            {
                //temp
                this.VM.AppliedVouchers.Add(new CheckoutViewModel.VoucherItem()
                {
                    Code = "Codere wrw21 ",
                    CodeDescription = "Code Description 12%"
                });
                //--
                this.IsCartValid = this.VM.IsCartValid;
                this.IsVoucherApplied = this.VM.AppliedVouchers.Count>0;
                this.CartHeaderIcon = this.VM.IsCartValid ? "\uf560" : "\uf071";
                this.CartHeaderIconColor = this.VM.IsCartValid ? Color.FromHex("#8ec63f") : Color.FromHex("#a31723");
                this.CartHeaderTitle = this.VM.ValidationTitle;
                this.CartHeaderBgColor = this.VM.IsCartValid ? Color.FromHex("#FFFFFF") : Color.FromHex("##f5bfc4");

                this.ValidationCaption = this.VM.ValidationCaption;
                this.ValidationMessages =new ObservableCollection<string> (this.VM.ValidationMessages);
                this.LineItems = new ObservableCollection<CheckoutViewModel.LineItem>(this.VM.LineItems);
                this.Vouchers = new ObservableCollection<CheckoutViewModel.VoucherItem>(this.VM.AppliedVouchers);
            }

            this.IsLoading = false;
        }

        private async void onItemTapCommand(Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            try
            {
                var item = (e.ItemData as StoreCategoryItem);
                //await Shell.Current.GoToAsync($"//Stores");
            }
            catch (Exception ex)
            {

            }
        }
    }
}
