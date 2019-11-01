using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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
        public string OTP { get; set; }

        public ICommand SignUpCommand { get; set; }
        public ICommand SendOtpCommand { get; set; }
        public ICommand ResetPwdCommand { get; set; }
        ApiService api { get; set; }
        IToastr toastr { get; set; }
        public LogInVewModelEx()
        {
            _isLoading = false; 
                _btnRegisterText = "REGISTER";
            
             api = new ApiService();
            toastr = DependencyService.Get<IToastr>();
            SignUpCommand = new Command(onSignUpCommand);
            SendOtpCommand = new Command(onSendOtpCommand);
            ResetPwdCommand = new Command(onResetPwdCommand);
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

        string _btnRegisterText;
        public string BtnRegisterText
        {
            get { return _btnRegisterText; }
            set
            {
                this._btnRegisterText = value;
                this.NotifyPropertyChanged();
            }
        }

        const string BTN_SEND_TEXT = "SEND";
        string _btnSendText = BTN_SEND_TEXT;
        public string BtnSendText
        {
            get { return _btnSendText; }
            set
            {
                this._btnSendText = value;
                this.NotifyPropertyChanged();
            }
        }


        //reset pwd page
        const string BTN_CONFIRM_TEXT = "SUBMIT";
        string _btnConfirmText = BTN_CONFIRM_TEXT;
        public string BtnConfirmText
        {
            get { return _btnConfirmText; }
            set
            {
                this._btnConfirmText = value;
                this.NotifyPropertyChanged();
            }
        }
        private async void onSignUpCommand()
        {
            try
            {
                if (IsLoading)
                    return;

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
                if (!Email.Contains("@") || !Email.Contains("."))
                {
                    toastr.ShowWarning("Invalid email format");
                    return;
                }
                if (MobileNumber.Length == 0)
                {
                    toastr.ShowWarning("Mobile number is required");
                    return;
                }
                if (!IsNumber(MobileNumber))
                {
                    toastr.ShowWarning("Mobile number must have digits only");
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
                
                

                var fistName = FullName;
                var lastName = string.Empty;
                if(FullName.Contains(" "))
                {
                    fistName = FullName.Split(' ')[0];
                    lastName = FullName.Split(' ')[1];
                }

                this.IsLoading = true;
                BtnRegisterText = "Wait...";
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
                else
                {
                    this.IsLoading = false;
                    BtnRegisterText = "REGISTER";
                }
            }
            catch (Exception ex)
            {
                this.IsLoading = false;
                BtnRegisterText = "REGISTER";
                toastr.ShowError(ex.Message);
            }
        }

        private async void onSendOtpCommand()
        {
            try
            {
                if (IsLoading)
                    return;

                Email = (Email ?? string.Empty).Trim();
               
                if (Email.Length == 0)
                {
                    toastr.ShowWarning("Email is required");
                    return;
                }
                if (!Email.Contains("@") || !Email.Contains("."))
                {
                    toastr.ShowWarning("Invalid email format");
                    return;
                }

                this.IsLoading = true;
                BtnSendText = "Wait...";
                var isSent = await api.CreatePasswordResetOTP(Email);

                if (isSent)
                {
                    toastr.ShowInfo("OTP sent");
                    await Task.Delay(500);
                    (App.Current as App).GoToResetPwd();
                }
                else
                {
                    this.IsLoading = false;
                    BtnSendText = BTN_SEND_TEXT;
                }
            }
            catch (Exception ex)
            {
                this.IsLoading = false;
                BtnSendText = BTN_SEND_TEXT;
                toastr.ShowError(ex.Message);
            }
        }

        private async void onResetPwdCommand()
        {
            try
            {
                if (IsLoading)
                    return;

                Password = (Password ?? string.Empty).Trim();
                OTP = (OTP ?? string.Empty).Trim();

                if (Password.Length == 0)
                {
                    toastr.ShowWarning("Password is required");
                    return;
                }
                if (OTP.Length == 0)
                {
                    toastr.ShowWarning("OTP is required");
                    return;
                }
               
                this.IsLoading = true;
                BtnConfirmText = "Wait...";
                var isDone = await api.ChangePassword(Email,Password,OTP);

                if (isDone)
                {
                    toastr.ShowInfo("Password updated");
                    await Task.Delay(500);
                    (App.Current as App).GoToLogIn();
                }
                else
                {
                    this.IsLoading = false;
                    BtnConfirmText = BTN_CONFIRM_TEXT;
                }
            }
            catch (Exception ex)
            {
                this.IsLoading = false;
                BtnConfirmText = BTN_CONFIRM_TEXT;
                toastr.ShowError(ex.Message);
            }
        }
        public  bool IsNumber(string str)
        {
            if (str == null)
                return false;

            if (str.Length == 0)
                return false;

            var isNumber = true;
            var chars = str.ToCharArray();
            for (var i = 0; i < chars.Length; i++)
            {
                if (!char.IsDigit(chars[i]))
                {
                    isNumber = false;
                    break;
                }
            }

            return isNumber;
        }
    }
}
