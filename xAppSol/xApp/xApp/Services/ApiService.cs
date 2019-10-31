﻿using Newtonsoft.Json;
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
       // string mobileUrl = string.Empty;
        string mobileV2Url = string.Empty;
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
            membershipUrl = apiEndpoint + "api/v1/membership/app/";
          //  mobileUrl = apiEndpoint + "api/v1/mobile/";
            mobileV2Url = apiEndpoint + "api/v2/mobile/";
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
        private async void handleError(HttpResponseMessage response)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                var content = await response.Content.ReadAsStringAsync();
                var index = content.IndexOf("message =", StringComparison.OrdinalIgnoreCase);
                if (index <= 0)
                    return;
                index += "message =".Length;
                //var error = JsonConvert.DeserializeObject<ErrorResponse>(content);
                var temp = content.Replace("}","").Substring(index).Trim();
                Device.BeginInvokeOnMainThread(() =>
                {
                    //this.Toastr.ShowError(error.Message);
                    this.Toastr.ShowError(temp);
                });
            }
        }
        private async Task<string>  getAuthToken()
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
            string data = JsonConvert.SerializeObject(new { userName,password});
            HttpContent reqData = new StringContent(data, Encoding.UTF8, "application/json");

            client.DefaultRequestHeaders.Add("app-id", AppId);
            client.DefaultRequestHeaders.Add("device-id", DeviceId);

            var response = await client.PostAsync(new Uri(membershipUrl + "login"), reqData);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<LogInResult>(content);
                return result.IsValid ? result.AuthToken : string.Empty;
            }
            return string.Empty;
        }

        public async Task<HomeViewResult2> GetHomeView()
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

            return null;
        }

        public async Task<AppViewModel> RefreshAppViewModel()
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

            return null;
        }

        public async Task<StoreInfoViewModel> StartShopping(string code)
        {
            code = encode(code);
            var response = await getHttp().PostAsync(new Uri(mobileV2Url + "store/startShopping/"+ code), toPostBody(null));
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<StoreInfoViewModel>(content);
                updatAppViewModel(result.AppView);
                return result;
            }
            else
                handleError(response);

            return null;
        }

        public async Task<StoreInfoViewModel> GetActiveStore()
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

            return null;
        }

        public async Task<AppViewModel> AddToCart(string code)
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

            return null;
        }

        public async Task<AppViewModel> RemoveFromCart(string code)
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

            return null;
        }

        public async Task<ShoppingCart> GetCurrentCart()
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
            else
                handleError(response);

            return null;
        }
    }

}
