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
        public ObservableCollection<OrderItem> _orders=new ObservableCollection<OrderItem> ();
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
        public async void OnLoad(int pageIndex = 1)
        {
            this.IsLoading = true;
            var model = new PagedItemRead
            {
                PageIndex = pageIndex,
                PageSize = PAGE_SIZE
            };
            PageIndex = 1;
            var vm =await new ApiService().ReadMyOrders(model);
            if (vm != null)
            {

                this.Orders = new ObservableCollection<OrderItem>(vm.Items);
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

        #region "TAB2"
        public int PageIndexDiscarded = 1;
        public bool IsLoading2 { get; set; }
        public bool IsNoRecord2 { get { return !IsLoading2 && this.DiscardedOrders.Count == 0; } }
        public ObservableCollection<OrderItem> _discardedOrders=new ObservableCollection<OrderItem> ();
        public ObservableCollection<OrderItem> DiscardedOrders
        {
            get
            {
                return _discardedOrders;
            }
            set
            {
                this._discardedOrders = value;
                this.NotifyPropertyChanged();
            }
        }

        public async void LoadDiscarded()
        {
            IsLoading2 = true;
            var model = new PagedItemRead
            {
                PageIndex = PageIndexDiscarded,
                PageSize = PAGE_SIZE
            };
            PageIndexDiscarded = 1;
            var vm =await new ApiService().ReadDiscardedOrders(model);
            if (vm != null)
            {
                this.DiscardedOrders = new ObservableCollection<OrderItem>(vm.Items);
            }
            IsLoading2 = false;
        }
        public ICommand LoadMoreDiscardedItemsCommand => new Command<object>(async (object obj) =>
        {
            var listView = obj as Syncfusion.ListView.XForms.SfListView;
            //Enables LoadMoreIndicator to the LoadMoreTemplate.
            listView.IsBusy = true;
            var delaytask = Task.Delay(2000);

            var model = new PagedItemRead
            {
                PageIndex = PageIndexDiscarded + 1,
                PageSize = PAGE_SIZE
            };

            var apitask = new ApiService().ReadDiscardedOrders(model);
            await Task.WhenAll(delaytask, apitask);
            var vm = apitask.Result;
            if (vm != null)
            {
                PageIndexDiscarded = vm.PageIndex;
                vm.Items.ForEach(o => DiscardedOrders.Add(o));
            }
            //Disables LoadMoreIndicator after adding the items.
            listView.IsBusy = false;
        });

        #endregion "TAB2"

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
