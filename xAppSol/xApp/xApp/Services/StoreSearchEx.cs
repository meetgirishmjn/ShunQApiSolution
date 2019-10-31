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
    public partial class StoreSearchEx : INotifyPropertyChanged
    {
        private ObservableCollection<StoreListViewModel.StoreListItem> _storeItems;
        public ObservableCollection<StoreListViewModel.StoreListItem> StoreItems
        {
            get
            {
                return _storeItems;
            }
            set
            {
                this._storeItems = value;
                this.NotifyPropertyChanged();
            }
        }
        public ICommand ItemTapCommand { get; set; }

        public StoreSearchEx()
        {
            this.IsLoading = true;
            this.StoreItems = new ObservableCollection<StoreListViewModel.StoreListItem>();
            this.ItemTapCommand = new Command<Syncfusion.ListView.XForms.ItemTappedEventArgs>(onItemTapCommand);
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
            }
        }


        public bool IsNotLoading
        {
            get { return !_isLoading; }
        }
        #endregion "IsLoading"

        public async void OnLoad()
        {
            var api = new ApiService();
            var vm = await api.StoreSearch(new SearcStoreRequestModel());

            if (vm != null)
            {
                this.StoreItems = new ObservableCollection<StoreListViewModel.StoreListItem>(vm.StoreList);
            }

            this.IsLoading = false;
        }

        private async void onItemTapCommand(Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            try
            {
                var item = (e.ItemData as StoreCategoryItem);
                await Shell.Current.GoToAsync($"//Stores");
            }
            catch (Exception ex)
            {

            }
        }
    }
}
