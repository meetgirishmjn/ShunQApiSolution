using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace xApp.Services
{
   public class LogInVewModelEx : INotifyPropertyChanged
    {
        public string FullName { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }

        public ICommand SignUpCommand { get; set; }
        ApiService api { get; set; }
        IToastr toastr { get; set; }
        public LogInVewModelEx()
        {
            var api = new ApiService();
            toastr = DependencyService.Get<IToastr>();
            SignUpCommand = new Command(onSignUpCommand);
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


        private async void onSignUpCommand()
        {
            try
            {
                FullName = (FullName ?? string.Empty).Trim();
                MobileNumber = (MobileNumber ?? string.Empty).Trim();
                Email = (Email ?? string.Empty).Trim();
                Password = (Password ?? string.Empty);
                if (FullName.Length == 0)
                {
                    toastr.ShowWarning("Name is required");
                    return;
                }
                if (Email.Length == 0)
                {
                    toastr.ShowWarning("Email is required");
                    return;
                }
                if (MobileNumber.Length == 0)
                {
                    toastr.ShowWarning("Mobile number is required");
                    return;
                }
                if (Password.Length == 0)
                {
                    toastr.ShowWarning("Password is required");
                    return;
                }
                if (Password != RePassword)
                {
                    toastr.ShowWarning("Confrim password does not match");
                    return;
                }
                if (!Email.Contains("@") || !Email.Contains("."))
                {
                    toastr.ShowWarning("Invalid email format");
                    return;
                }
                if (MobileNumber.Length!=10)
                {
                    toastr.ShowWarning("Mobile number must have 10 digits only");
                    return;
                }

                var fistName = FullName;
                var lastName = string.Empty;
                if(FullName.Contains(" "))
                {
                    fistName = FullName.Split(' ')[0];
                    lastName = FullName.Split(' ')[1];
                }


              var result =await  api.RegisterUser(new RegisterUserModel 
                {
                    FirstName=fistName,
                    LastName= lastName,
                    Email=Email,
                    MobileNumber=MobileNumber,
                     Password=Password
                });

                if (result != null)
                {
                    await SecureStorage.SetAsync("oAuthToken", result.AuthToken);
                    App.Current.MainPage = new AppLaunch();
                }
            }
            catch (Exception ex)
            {
                toastr.ShowError(ex.Message);
            }
        }
    }
}
