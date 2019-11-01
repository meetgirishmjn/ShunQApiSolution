using System;
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
    public partial class LoginPage
    {
        public bool IsLoading { get; set; }
        public bool IsNotLoading { get { return !IsLoading; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPage" /> class.
        /// </summary>
        public LoginPage()
        {
            InitializeComponent();
            Email.Text = "meetgirish.mjn@gmail.com";
            PasswordEntry.Text = "admin@mjngrs";
        }

        private async void LogIn_Clicked(object sender, System.EventArgs e)
        {
            if (IsLoading)
                return;

            IsLoading = true;
            btnLogIn.Text = "Please wait...";

            try
            {
                var token = await new ApiService().LogIn(Email.Text, PasswordEntry.Text);
                if (string.IsNullOrEmpty(token))
                    throw new Exception("Invalid credentials");


                await SecureStorage.SetAsync("oAuthToken", token);
                App.Current.MainPage = new AppLaunch();

            }
            catch (Exception ex)
            {
                await DisplayAlert("Log-In", ex.Message, "Ok");
            }
            finally
            {
                IsLoading = false;
                btnLogIn.Text = "LOG IN";
            }
        }

        private void btnSignUp_Clicked(object sender, EventArgs e)
        {
            (App.Current as App).GoToSignUp();
        }

        private void ForgotPasswordLabel_Tapped(object sender, EventArgs e)
        {
            (App.Current as App).GoToForgotPwd();
        }
    }
}
