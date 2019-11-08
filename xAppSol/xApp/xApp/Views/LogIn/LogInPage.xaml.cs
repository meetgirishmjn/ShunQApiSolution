using Plugin.FacebookClient;
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
        IToastr toastr;
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPage" /> class.
        /// </summary>
        public LoginPage()
        {
            InitializeComponent();
            toastr = DependencyService.Get<IToastr>();
        }

        private async void LogIn_Clicked(object sender, System.EventArgs e)
        {
            if (IsLoading)
                return;

            IsLoading = true;
            btnLogIn.Text = "Please wait...";
            btnLogIn.Focus();
            try
            {

                var email = (Email.Text ?? string.Empty).Trim();
                var password = (PasswordEntry.Text ?? string.Empty);

                if (email.Length == 0)
                {
                    toastr.ShowInfo("Email is required");
                    return;
                }
                if (!email.Contains("@") || !email.Contains("."))
                {
                    toastr.ShowInfo("Invalid email format");
                    return;
                }
                if (password.Length == 0)
                {
                    toastr.ShowInfo("Password is required");
                    return;
                }
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


        const string FB_BTN_TEXT = "Login with Facebook";
        private async void onFbLoginCommand(object sender, EventArgs e)
        {
            try
            {
                
                if(toastr == null)
                    toastr = DependencyService.Get<IToastr>();

               var res = await CrossFacebookClient.Current.RequestUserDataAsync(new string[] { "email", "first_name",  "last_name" }, new string[] { "email" });

                if (res.Status != FacebookActionStatus.Completed)
                    throw new Exception("Something went wrong. Check your connection.");
                
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<FbResult>(res.Data);

                if(result.email==null|| result.email.Contains("@")==false)
                    throw new Exception("Something went wrong. Check your connection.");

                btnFbLogin.IsEnabled = false;
                lblFbLogin.Text = "Please wait...";

                var model = new LoginOauthModel
                {
                    Email = result.email,
                    FullName = result.first_name + " " + result.last_name,
                    ProfileId = result.id,
                    ProviderName = "FACEBOOK"
                };

                var token = await new ApiService().LogInSocial(model);
                if (!string.IsNullOrEmpty(token))
                {
                    await SecureStorage.SetAsync("oAuthToken", token);
                    App.Current.MainPage = new AppLaunch();
                }

            }
            catch (Exception ex)
            {
                 toastr.ShowError(ex.Message);
            }
            finally
            {
                btnFbLogin.IsEnabled = true;
                lblFbLogin.Text = FB_BTN_TEXT;
            }
        }

        private void onGoogleLoginCommand(object sender, EventArgs e)
        {
            try
            {
                if (toastr == null)
                    toastr = DependencyService.Get<IToastr>();

                toastr.ShowInfo("Feature not implemented");
            }
            catch (Exception ex)
            {
                toastr.ShowError(ex.Message);
            }
        }

    }

    public class FbResult
    {
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string id { get; set; }
    }
}
