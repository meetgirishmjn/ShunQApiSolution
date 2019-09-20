using BusinessCore.Services.Contracts;
using BusinessCore.Services.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCore.Services
{
   public class SmsGateway: ISmsGateway
    {
        const string GATEWAY_ENDPOINT = "https://2factor.in/API/V1/{api_key}/SMS/{phone_number}/{otp}";
        public async Task<SmsSendResult> SendSms(string mobileNumber, string opt)
        {
            var result = new SmsSendResult();
            try
            {
                using (var httpClient = new HttpClient())
                {

                    using (var response = await httpClient.GetAsync(GATEWAY_ENDPOINT.Replace("{phone_number}", mobileNumber).Replace("{otp}", opt)))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        dynamic obj = JsonConvert.DeserializeObject(apiResponse);
                    }
                }
                result.HasError = false;
            }
            catch (Exception ex)
            {
                result.HasError = true;
            }
            return result;
        }

    }
}
