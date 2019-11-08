using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using xApp.Models;
using xApp.ViewModels;

namespace xApp.Services
{
    public class ApiService
    {
        HttpClient client;
        string apiEndpoint = "https://shunq-api-dev.azurewebsites.net/";
        string membershipUrl = string.Empty;
        string mobileUrl = string.Empty;
        string mobileV2Url = string.Empty;
        string merchantUrl = string.Empty;
        public static string __deviceId = string.Empty;
        public IToastr Toastr { get; set; }

        public string AppId = "appGrs123";
        public static string _AuthToken { get; set; }
        public string AuthToken { get { return _AuthToken; } }

        public static string DeviceId
        {
            get
            {
                if (__deviceId == string.Empty)
                {
                    __deviceId = DependencyService.Get<IToastr>().GetDeviceId();
                }
                return __deviceId;
            }
        }

        public ApiService()
        {
            client = new HttpClient();
            membershipUrl = apiEndpoint + "api/v1/membership/";
            mobileUrl = apiEndpoint + "api/v1/mobile/";
            mobileV2Url = apiEndpoint + "api/v2/mobile/";
            merchantUrl = apiEndpoint + "api/v1/merchant/";
            Toastr = DependencyService.Get<IToastr>();
        }
        private HttpClient getHttp()
        {
            this.client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authorization", "bearer " + AuthToken);
            client.DefaultRequestHeaders.Add("app-id", this.AppId);
            client.DefaultRequestHeaders.Add("device-id", ApiService.DeviceId);
            return client;
        }

        private HttpContent toPostBody(object postBody)
        {
            string data = null;

            if (postBody == null)
                data = "{}";
            else
                data = JsonConvert.SerializeObject(postBody);

            HttpContent reqContent = new StringContent(data, Encoding.UTF8, "application/json");
            return reqContent;
        }
        private void updatAppViewModel(AppViewModel model)
        {
            AppViewModel.Instance.HasActiveCart = model.HasActiveCart;
            AppViewModel.Instance.UserName = model.UserName;
            AppViewModel.Instance.FullName = model.FullName;
            AppViewModel.Instance.HasActiveCart = model.HasActiveCart;
            AppViewModel.Instance.CartItemCount = model.CartItemCount;
        }
        private string encode(string text)
        {
            return text.Replace("/", "").Replace("\\", "").Replace("&", "");
        }

        private async void handleInternetError(Exception ex)
        {
            Device.BeginInvokeOnMainThread(() => this.Toastr.ShowError("Internet not reachable. Check connection."));
        }
        private async void handleError(HttpResponseMessage response)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                var content = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorResponse>(content);
                Device.BeginInvokeOnMainThread(() =>
                {
                    this.Toastr.ShowError(error.Message);
                });
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    this.Toastr.ShowError("Session expired");
                    (App.Current as App).GoToLogIn();
                });
            }
            else
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    this.Toastr.ShowError("Critical server error occurred");
                });
            }
        }
        private async Task<string> getAuthToken()
        {
            var token = "";
            try
            {
                token = await Xamarin.Essentials.SecureStorage.GetAsync("oAuthToken");
            }
            catch (Exception ex)
            {
                // Possible that device doesn't support secure storage on device.
            }

            return token;
        }
        public async Task<string> LogIn(string userName, string password)
        {
            try
            {
                string data = JsonConvert.SerializeObject(new { userName, password });
                HttpContent reqData = new StringContent(data, Encoding.UTF8, "application/json");

                client.DefaultRequestHeaders.Add("app-id", AppId);
                client.DefaultRequestHeaders.Add("device-id", DeviceId);

                var response = await client.PostAsync(new Uri(membershipUrl + "app/login"), reqData);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<LogInResult>(content);
                    return result.IsValid ? result.AuthToken : string.Empty;
                }
            }
            catch (Exception ex)
            {
                handleInternetError(ex);
            }
            return string.Empty;
        }

        public async Task<string> LogInSocial(LoginOauthModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                HttpContent reqData = new StringContent(data, Encoding.UTF8, "application/json");

                client.DefaultRequestHeaders.Add("app-id", AppId);
                client.DefaultRequestHeaders.Add("device-id", DeviceId);

                var response = await client.PostAsync(new Uri(membershipUrl + "app/oauth/login"), reqData);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<LogInResult>(content);
                    return result.IsValid ? result.AuthToken : string.Empty;
                }
            }
            catch (Exception ex)
            {
                handleInternetError(ex);
            }
            return string.Empty;
        }
        public async Task<bool> Logout()
        {
            try
            {
                var response = await getHttp().PostAsync(new Uri(membershipUrl + "app/logout"), null);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                    handleError(response);
            }
            catch (Exception ex)
            {
                handleInternetError(ex);
            }
            return false;
        }

        public async Task<RegisterUserViewModel> RegisterUser(RegisterUserModel userInfo)
        {
            try
            {
                var response = await getHttp().PostAsync(new Uri(membershipUrl + "app/register"), toPostBody(userInfo));
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<RegisterUserViewModel>(content);
                    return result;
                }
                else
                    handleError(response);
            }
            catch (Exception ex)
            {
                handleInternetError(ex);
            }
            return null;
        }

        public async Task<bool> ChangePassword(string userName, string newPwd, string otp)
        {
            try
            {
                var response = await getHttp().PostAsync(new Uri(membershipUrl + "change/password"), toPostBody(new { UserName = userName, Password = newPwd, OTP = otp }));
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                    handleError(response);
            }
            catch (Exception ex)
            {
                handleInternetError(ex);
            }
            return false;
        }

        public async Task<bool> CreatePasswordResetOTP(string userName)
        {
            try
            {
                var response = await getHttp().PostAsync(new Uri(membershipUrl + "password/otp/" + userName), null);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                    handleError(response);
            }
            catch (Exception ex)
            {
                handleInternetError(ex);
            }
            return false;
        }


        public async Task<HomeViewResult2> GetHomeView()
        {
            try
            {
                var response = await getHttp().GetAsync(new Uri(mobileV2Url + "views/home"));
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<HomeViewResult2>(content);
                    updatAppViewModel(result.AppView);
                    return result;
                }
                else
                    handleError(response);
            }
            catch (Exception ex)
            {
                handleInternetError(ex);
            }
            return null;
        }

        public async Task<AppViewModel> RefreshAppViewModel()
        {
            try
            {
                var response = await getHttp().GetAsync(new Uri(mobileV2Url + "app/view"));
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<AppViewModel>(content);
                    updatAppViewModel(result);
                    return AppViewModel.Instance;
                }
                else
                    handleError(response);
            }
            catch (Exception ex)
            {
                handleInternetError(ex);
            }
            return null;
        }

        public async Task<StoreInfoViewModel> StartShopping(string code)
        {
            try
            {
                code = encode(code);
                var response = await getHttp().PostAsync(new Uri(mobileV2Url + "store/startShopping/" + code), toPostBody(null));
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<StoreInfoViewModel>(content);
                    updatAppViewModel(result.AppView);
                    return result;
                }
                else
                    handleError(response);
            }
            catch (Exception ex)
            {
                handleInternetError(ex);
            }
            return null;
        }

        public async Task<StoreInfoViewModel> GetActiveStore()
        {
            try
            {
                var response = await getHttp().GetAsync(new Uri(mobileV2Url + "active/store"));
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<StoreInfoViewModel>(content);
                    updatAppViewModel(result.AppView);
                    return result;
                }
                else
                    handleError(response);
            }
            catch (Exception ex)
            {
                handleInternetError(ex);
            }
            return null;
        }

        public async Task<AppViewModel> AddToCart(string code)
        {
            try
            {
                code = encode(code);
                var response = await getHttp().PostAsync(new Uri(mobileV2Url + "cart/add/" + code), null);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<AppViewModel>(content);
                    updatAppViewModel(result);
                    return result;
                }
                else
                    handleError(response);
            }
            catch (Exception ex)
            {
                handleInternetError(ex);
            }
            return null;
        }

        public async Task<AppViewModel> RemoveFromCart(string code)
        {
            try
            {
                code = encode(code);
                var response = await getHttp().PostAsync(new Uri(mobileV2Url + "cart/remove/" + code), null);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<AppViewModel>(content);
                    updatAppViewModel(result);
                    return result;
                }
                else
                    handleError(response);
            }
            catch (Exception ex)
            {
                handleInternetError(ex);
            }
            return null;
        }

        public async Task<ShoppingCart> GetCurrentCart()
        {
            try
            {
                var response = await getHttp().GetAsync(new Uri(mobileV2Url + "current/cart"));
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ShoppingCart>(content);
                    updatAppViewModel(new AppViewModel
                    {
                        CartItemCount = result.ItemCount,
                        HasActiveCart = true,
                        FullName = result.FullName,
                        UserName = result.UserName
                    });
                    return result;
                }
                //else
                //    handleError(response);
            }
            catch (Exception ex)
            {
                handleInternetError(ex);
            }
            return null;
        }

        public async Task<List<StoreCategoryItem>> GetStoreCategories()
        {
            try
            {
                var response = await getHttp().GetAsync(new Uri(mobileV2Url + "store/category"));
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var results = JsonConvert.DeserializeObject<List<StoreCategoryItem>>(content);
                    return results;
                }
                else
                    handleError(response);
            }
            catch (Exception ex)
            {
                handleInternetError(ex);
            }
            return new List<StoreCategoryItem>();
        }

        public async Task<SearchStoresViewModel> StoreSearch(StoreListModel req)
        {
            try
            {
                var response = await getHttp().PostAsync(new Uri(mobileUrl + "views/searchStores"), toPostBody(req));
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<SearchStoresViewModel>(content);
                    return result;
                }
                else
                    handleError(response);
            }
            catch (Exception ex)
            {
                handleInternetError(ex);
            }
            return null;
        }

        public async Task<CheckoutViewModel> GetCheckoutView()
        {
            try
            {
                var response = await getHttp().GetAsync(new Uri(mobileUrl + "views/checkout"));
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<CheckoutViewModel>(content);
                    return result;
                }
                else
                    handleError(response);
            }
            catch (Exception ex)
            {
                handleInternetError(ex);
            }
            return null;
        }

        public async Task<CheckoutViewModel> ApplyVoucherCode(string code)
        {
            try
            {
                code = encode(code);
                var response = await getHttp().PostAsync(new Uri(mobileUrl + "checkout/add/voucher/" + code), null);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<CheckoutViewModel>(content);
                    return result;
                }
                else
                    handleError(response);
            }
            catch (Exception ex)
            {
                handleInternetError(ex);
            }
            return null;
        }

        public async Task<CheckoutViewModel> RemoveVoucherCode(string code)
        {
            try
            {
                code = encode(code);
                var response = await getHttp().PostAsync(new Uri(mobileUrl + "checkout/remove/voucher/" + code), null);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<CheckoutViewModel>(content);
                    return result;
                }
                else
                    handleError(response);
            }
            catch (Exception ex)
            {
                handleInternetError(ex);
            }
            return null;
        }
        public async Task<PaySuccessInfoVM> GetPaySuccessInfo(string cartId)
        {
            try
            {
                var response = await getHttp().GetAsync(new Uri(merchantUrl + "app/pay/success/detail/"+ cartId));
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<PaySuccessInfoVM>(content);
                    return result;
                }
                else
                    handleError(response);
            }
            catch (Exception ex)
            {
                handleInternetError(ex);
            }
            return null;
        }

        public async Task<DiscardCartViewModel> DiscardCart()
        {
            try
            {
                var response = await getHttp().PostAsync(new Uri(mobileV2Url + "cart/discard"),null);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<DiscardCartViewModel>(content);
                    updatAppViewModel(new AppViewModel
                    {
                        CartItemCount = result.CartItemCount,
                        HasActiveCart = false,
                        FullName = result.FullName,
                        UserName = result.UserName,
                    });
                    return result;
                }
                else
                    handleError(response);
            }
            catch (Exception ex)
            {
                handleInternetError(ex);
            }
            return null;
        }
         
    }

}
