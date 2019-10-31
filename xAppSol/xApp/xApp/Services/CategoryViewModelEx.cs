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
   public partial class CategoryViewModelEx : INotifyPropertyChanged
    {
        private ObservableCollection<StoreCategoryItem>_categoryItems;
        public ObservableCollection<StoreCategoryItem> CategoryItems
        {
            get
            {
                return _categoryItems;
            }
            set
            {
                this._categoryItems = value;
                this.NotifyPropertyChanged();
            }
        }
        public ICommand ItemTapCommand { get; set; }

        public CategoryViewModelEx()
        {
            this.IsLoading = true;
            this.CategoryItems = new ObservableCollection<StoreCategoryItem>();
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
            var results = await api.GetStoreCategories();

            results.ForEach(o => o.ImageUrl = App.AppImageUrl + "app/Album2.png");

            this.CategoryItems = new ObservableCollection<StoreCategoryItem>(results);
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
