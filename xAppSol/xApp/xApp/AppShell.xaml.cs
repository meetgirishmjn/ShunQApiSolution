using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using xApp.ViewModels;

namespace xApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            this.BindingContext = AppViewModel.Instance.CurrentUser;
        }

        protected override bool OnBackButtonPressed()
        {
            if (Application.Current.MainPage.GetType() == typeof(AppShell) && Shell.Current.Navigation.NavigationStack.Where(x => x != null).Any())
            {
                return base.OnBackButtonPressed();
            }
            else
            {
                System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
                return true;
            }
        }


        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new Views.LogIn.LoginPage());
        }
    }
}
