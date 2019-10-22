using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using xApp.Models;

namespace xApp.Services
{
    public class ApiService
    {
        HttpClient client;
        string apiEndpoint = "https://shunq-api-dev.azurewebsites.net/";
        string membershipUrl = string.Empty;
        string mobileUrl = string.Empty;
        public static string __deviceId = string.Empty;

        public string AppId = "appGrs123";

        
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
            membershipUrl = apiEndpoint + "/api/v1/membership/app/";
            mobileUrl = apiEndpoint + "/api/v1/mobile/";
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

        public async 
        public async Task<string> GetHomeView()
        {
            var response = await client.GetAsync(new Uri(mobileUrl + "views/home"));
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<LogInResult>(content);
                return result.IsValid ? result.AuthToken : string.Empty;
            }
            return string.Empty;
        }
    }

    public class LogInResult
    {
        public bool IsValid { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string AuthToken { get; set; }
    }

    public class HomeViewResult
    {
        public string[] BannerUrls { get; set; }
        public bool HasActiveCart { get; set; }
    }
}
