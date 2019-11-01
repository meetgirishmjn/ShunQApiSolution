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
        public IToastr toastr { get; set; }
        public ApiService api { get; set; }
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
                this.IsVoucherApplied = _vouchers.Count > 0;
                this.NotifyPropertyChanged();
                this.NotifyPropertyChanged(nameof(IsVoucherApplied));
                this.NotifyPropertyChanged(nameof(IsNoVoucherApplied));
            }
        }

        public ICommand ApplyVoucherCommand { get; set; }
        public ICommand RemoveVoucherCommand { get; set; }

        public CheckoutViewModelEx()
        {
            this.IsLoading = true;
            this.LineItems = new ObservableCollection<CheckoutViewModel.LineItem>();
            toastr = DependencyService.Get<IToastr>();
            ApplyVoucherCommand = new Command(onApplyVoucherCommand);
           // RemoveVoucherCommand = new Command(onRemoveVoucherCommand);
            api = new ApiService();

        }

        public CheckoutViewModel VM { get; set; }

        //   Icon = "\uf1da"
        public string CartHeaderIcon  { get; set; }
        public Color CartHeaderIconColor  { get; set; }
        public string CartHeaderTitle { get; set; }
        public string ItemHeaderTitle { get { return this.VM==null?"Item(s)":("Item(s) - " + this.VM.TotalItem); } }
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
                this.NotifyPropertyChanged(nameof(ItemHeaderTitle));
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

        public float TotalAmount { get; set; }
        public float TotalDiscount { get; set; }
        public float TotalVoucherDiscount { get; set; }
        public float OrderTotal { get; set; }
        
        private void UpdateUIPriceInfo()
        {
            this.TotalAmount = VM.TotalAmount;
            this.TotalDiscount = VM.TotalDiscount;
            this.TotalVoucherDiscount = VM.TotalVoucherDiscount;
            this.OrderTotal = VM.OrderTotal;
            this.NotifyPropertyChanged(nameof(IsVoucherApplied));
            this.NotifyPropertyChanged(nameof(IsNoVoucherApplied));
            this.NotifyPropertyChanged(nameof(TotalAmount));
            this.NotifyPropertyChanged(nameof(TotalDiscount));
            this.NotifyPropertyChanged(nameof(TotalVoucherDiscount));
            this.NotifyPropertyChanged(nameof(OrderTotal));
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
                
                //--
                this.IsCartValid = this.VM.IsCartValid;
               
                this.CartHeaderIcon = this.VM.IsCartValid ? "\uf560" : "\uf071";
                this.CartHeaderIconColor = this.VM.IsCartValid ? Color.FromHex("#8ec63f") : Color.FromHex("#a31723");
                this.CartHeaderTitle = this.VM.ValidationTitle;
                this.CartHeaderBgColor = this.VM.IsCartValid ? Color.FromHex("#FFFFFF") : Color.FromHex("##f5bfc4");

                this.ValidationCaption = this.VM.ValidationCaption;
                this.ValidationMessages =new ObservableCollection<string> (this.VM.ValidationMessages);
                this.LineItems = new ObservableCollection<CheckoutViewModel.LineItem>(this.VM.LineItems);
                this.Vouchers = new ObservableCollection<CheckoutViewModel.VoucherItem>(this.VM.AppliedVouchers);
                UpdateUIPriceInfo();
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

        public string _voucherCodeEntry=string.Empty;
        public string VoucherCodeEntry
        {
            get { return _voucherCodeEntry; }
            set { _voucherCodeEntry = value; NotifyPropertyChanged(); }
        }
        private async void onApplyVoucherCommand()
        {
            try
            {
                if (VoucherCodeEntry == null)
                    return;

                var code = VoucherCodeEntry.Trim();
                if (code.Length == 0)
                {
                    toastr.ShowError("Please enter code");
                    return;
                }
                var result = await api.ApplyVoucherCode(code);
                if (result != null)
                {
                    this.VM = result;
                    VoucherCodeEntry = string.Empty;
                    this.Vouchers = new ObservableCollection<CheckoutViewModel.VoucherItem>(result.AppliedVouchers);
                    UpdateUIPriceInfo();
                    toastr.ShowInfo("Voucher applied successfully.");

                }
            }
            catch (Exception ex)
            {

            }
        }
        public async void onRemoveVoucherCommand(string code)
        {
            try
            {
                var result = await api.RemoveVoucherCode(code);
                if (result != null)
                {
                    this.VM = result;
                    VoucherCodeEntry = string.Empty;
                    this.Vouchers = new ObservableCollection<CheckoutViewModel.VoucherItem>(result.AppliedVouchers);
                    UpdateUIPriceInfo();
                    toastr.ShowInfo("Voucher removed successfully.");
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
