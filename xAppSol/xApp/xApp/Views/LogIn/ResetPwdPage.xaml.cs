﻿using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using xApp.Services;

namespace xApp.Views.LogIn
{

    /// <summary>
    /// Page to login with user name and password
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResetPwdPage
    {
        public ResetPwdPage()
        {
            InitializeComponent();
            this.BindingContext = new LogInVewModelEx();
        }

        private void btnLogIn_Clicked(object sender, EventArgs e)
        {
            (App.Current as App).GoToLogIn();
        }
    }
}