using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace xApp.Services
{
    public class MyOrdersViewModel : BaseVM
    {
        public ObservableCollection<OrderItem> _orders;
        public ObservableCollection<OrderItem> Orders
        {
            get
            {
                return _orders;
            }
            set
            {
                this._orders = value;
                this.NotifyPropertyChanged();
            }
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
                this.NotifyPropertyChanged(nameof(IsNoRecord));
            }
        }
        public bool IsNotLoading
        {
            get { return !_isLoading; }
        }
        #endregion "IsLoading"
        public bool IsNoRecord { get { return !IsLoading && this.Orders.Count == 0; } }

        bool _isLoadingMore = false;
        public bool IsLoadingMore
        {
            get
            {
                return _isLoadingMore;
            }
            set
            {
                this._isLoadingMore = value;
                this.NotifyPropertyChanged();
            }
        }

        const int PAGE_SIZE = 20;
        public void OnLoad(int pageIndex = 1)
        {
            this.IsLoading = true;
            var model = new PagedItemRead
            {
                PageIndex = pageIndex,
                PageSize = PAGE_SIZE
            };
            PageIndex = 1;
            var vm = new ApiService().ReadMyOrders(model);
            if (vm != null)
            {

                this.Orders = new ObservableCollection<OrderItem>(vm.Result.Items);
            }
            this.IsLoading = false;
        }

        public int PageIndex=1;
        public ICommand LoadMoreItemsCommand => new Command<object>(async (object obj) =>
        {
            var listView = obj as Syncfusion.ListView.XForms.SfListView;
            IsLoadingMore = true;
            //Enables LoadMoreIndicator to the LoadMoreTemplate.
            listView.IsBusy = true;
            var delaytask = Task.Delay(2000);

            var model = new PagedItemRead
            {
                PageIndex = PageIndex + 1,
                PageSize = PAGE_SIZE
            };

            var apitask = new ApiService().ReadMyOrders(model);
            await Task.WhenAll(delaytask, apitask);
            var vm = apitask.Result;
            if (vm != null)
            {
                PageIndex = vm.PageIndex;
                vm.Items.ForEach(o => Orders.Add(o));
            }
            IsLoadingMore = false;
            //Disables LoadMoreIndicator after adding the items.
            listView.IsBusy = false;
        });
       
    }

    public partial class OrderItem
    {
        public string OrderDesc { get
            {
                
                if (!IsSuccess)
                    return "Payment not made. Please contact support.";

                return string.Format("{0}:0.00", Amount) + " - " + OrderDate.ToShortDateString();
            }
        }
        public object StatusColor
        {
            get
            {
                if(IsSuccess)
                    return Application.Current.Resources["Green"];
                else
                    return Application.Current.Resources["Red"];
            }
        }
    }
}
