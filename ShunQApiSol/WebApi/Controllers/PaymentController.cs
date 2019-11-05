using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessCore;
using BusinessCore.AppHandlers;
using BusinessCore.Extensions;
using BusinessCore.Models;
using BusinessCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApi.RequestModels;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/v1/merchant")]
    [ApiController]
    [Authorize]
    public class PaymentController : BaseController
    {
        public PaymentController(IServiceProvider serviceProvider, IOptions<AppConfig> appConfig) : base(serviceProvider, appConfig)
        {
        }

        string computeSha512Hash(string strToHash)
        {
            // Create a SHA256   
            using (var sha512 = System.Security.Cryptography.SHA512Managed.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(strToHash));
                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        [HttpGet("app/payu/init")]
        [AllowAnonymous]
        public InitPayUViewModel  InitPayU()
        {
            var service = CreateStoreService();
            var tokens = this.AppConfig.MerchangePaymentTokenTest.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            var cart = service.GetCart();
            cart = new ShoppingCart();
            if (cart == null)
                throw new BusinessException("Cart does not exist");

            cart.NetAmount = 2867.65F;
            if (cart.NetAmount <= 0)
                throw new BusinessException("Invalid net-amount in Cart");

            var salt = tokens[1];

            cart.Id = "ciererewgrsmjn";
            CurrentUser = new UserInfo
            {
                FullName = "Girish Mahajan",
                MobileNumber = "8871384762",
                Email = "meetgirish.mjn@gmail.com",
            };

            var vm = new InitPayUViewModel()
            {
                IsDebug = true,
                Key = tokens[0],
                Amount = cart.NetAmount,
                Email = CurrentUser.Email,
                Phone = CurrentUser.MobileNumber,
                firstName = CurrentUser.FullName,
                TxnId = cart.Id,
                ProductName = "Purchase at " + "cart.StoreName",
                udf1 = "u1",
                udf2 = "u2",
                udf3 = "u3",
                udf4 = "u4",
                udf5 = "u5",
                surl = AppConfig.CoreApiEndpoint + "merchant/pay/callback/success",
                furl = AppConfig.CoreApiEndpoint + "merchant/pay/callback/failure",
                ColorCode = "#0173CF",
                LogoUrl = AppConfig.ImageSrcEndpoint + "app/logo_light_sm.png"
            };

            string shaIn = $"{vm.Key}|{vm.TxnId}|{vm.Amount}|{vm.ProductName}|{vm.firstName}|{vm.Email}|{vm.udf1}|{vm.udf2}|{vm.udf3}|{vm.udf4}|{vm.udf5}||||||{salt}";
            
            var shaBytes = Encoding.UTF8.GetBytes(shaIn);
            using (var shaM = new System.Security.Cryptography.SHA512Managed())
            {
                var hash = shaM.ComputeHash(shaBytes);
                vm.HashCode = getHashString(hash);
            }

            return vm;
        }

        [HttpPost("pay/callback/success")]
        [AllowAnonymous]
        public ContentResult OnPaymentSuccess()
        {
            BusinessCore.AppHandlers.Contracts.ILoggerManager logger = null;

            var status = "";
            var txnid = "";
            var payuMoneyId = "";
            var payURes = "";
            var email = "";
            try
            {
                //take status for safety
                status = Request.Form["status"].ToString();
                txnid = Request.Form["txnid"].ToString();
                payuMoneyId = Request.Form["payuMoneyId"].ToString();
                email = Request.Form["payuMoneyId"].ToString();
                logger = CreateLogger();
                //var payURes = new PayUSuccessModel().ReadFrom(Request.Form);
                payURes = new PayUSuccessModel().ReadAsString(Request.Form);
                logger.LogInfo(payURes);
            }
            catch(Exception ex)
            {
                if (logger != null)
                    logger.LogError("Error at pay/callback/success: " + ex.Message);
            }

            try
            {
                var hashValidated = isPayUResponseHashValidated();
                var service = CreateStoreService();
                var voucher = new CartVoucher()
                {
                    PaymentGatewayName = "PayU",
                    CartId = txnid,
                    GatewayPaymentId = payuMoneyId,
                    GatewayResponse = payURes,
                    Status = status,
                    IsSuccess = status.Equals("success", StringComparison.OrdinalIgnoreCase),
                    UserEmail= email,
                    HashValidated=hashValidated
                };
                service.CreateCartVoucher(voucher);
            }
            catch (Exception ex)
            {
                logger.LogError("Error at pay/callback/success: voucher creation " + ex.Message);
            }

            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = (int)System.Net.HttpStatusCode.OK,
                Content = "<i> Please wait... </i>"
            };
        }

        [HttpGet("app/pay/success/detail/{cartId}")]
        public PaySuccessInfoVM GetPaymentSuccessInfo(string cartId)
        {
            var result = new PaySuccessInfoVM();
            var service = CreateStoreService();
            var paymentVoucher = service.GetCartVoucher(cartId);
            result.IsSuccess = paymentVoucher.IsSuccess;
            result.CheckoutCode = new IdToCodeConverter().ToCode(paymentVoucher.VoucherId);

            if (!result.IsSuccess)
            {
                result.ErrorMessage = "Payment status not pending. Please contact store administrator.";
            }

            return result;
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [HttpPost("pay/callback/failure")]
        [AllowAnonymous]
        public ContentResult OnPaymentFailure()
        {
            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = (int)System.Net.HttpStatusCode.OK,
                Content = "<i>Please Wait...</i><script>var msgData = { eventName: 'onPaymentFailed', eventData: { message: 'this.store.id'}}; var jsBridge = window.jsBridge; if (jsBridge && jsBridge.invokeAction) { jsBridge.invokeAction(JSON.stringify(data)); }</script>"
            };
            // return Ok();
        }


        private  string getHashString(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2").ToLower());
            }
            return result.ToString();
        }


      

        [HttpGet("pay/checkout-launch")]
        [AllowAnonymous]
        public ContentResult GetPayUHtml()
        {
            byte[] hash;
            var data = new { key = "KTiotDpI", txnid = "T124", amount = 12.75, productinfo = "My G Product", firstname = "Grs", email = "meetgirish.mjn@gmail.com",mobile="8871384762", udf1 = "u1", udf2 = "u2", udf3 = "u3", udf4 = "u4", udf5 = "u5", SALT = "" };

            // before  sha512(key|txnid|amount|productinfo|firstname|email|udf1|udf2|udf3|udf4|udf5||||||SALT)
            // after   sha512(SALT|status||||||udf5|udf4|udf3|udf2|udf1|email|firstname|productinfo|amount|txnid|key) 

            string shaIn = $"{data.key}|{data.txnid}|{data.amount}|{data.productinfo}|{data.firstname}|{data.email}|{data.udf1}|{data.udf2}|{data.udf3}|{data.udf4}|{data.udf5}||||||{data.SALT}";

            var shaBytes = Encoding.UTF8.GetBytes(shaIn);
            using (var shaM = new System.Security.Cryptography.SHA512Managed())
            {
                hash = shaM.ComputeHash(shaBytes);
            }
            var hashStr = getHashString(hash);

            var sbHtml = new StringBuilder();
            var logoUrl = AppConfig.ImageSrcEndpoint + "app/logo_light_sm.png";

            var launchStr = string.Format("key:'{0}',txnid:'{1}',hash:'{2}',amount:{3},firstname:'{4}',email:'{5}',phone:'{6}',productinfo:'{7}',udf5:'{8}',surl:'{9}',furl:'{10}'", data.key, data.txnid, hashStr, data.amount, data.firstname, data.email, data.mobile, data.productinfo, data.udf5, AppConfig.CoreApiEndpoint + "merchant/pay/callback/success", AppConfig.CoreApiEndpoint + "merchant/pay/callback/failure");
            sbHtml.Append("<!DOCTYPE html> <html lang = \"en\"> <head><meta name=\"viewport\" content=\"width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no\" > ");
            sbHtml.Append("<script id=\"bolt\" src=\"https://sboxcheckout-static.citruspay.com/bolt/run/bolt.min.js\" bolt-color=\"#0173CF\" bolt-logo=\"" + logoUrl + "\"></script></head>");
            sbHtml.Append("<body><script type=\"text/javascript\">bolt.launch({"+ launchStr + "},{responseHandler:function(BOLT){console.log(BOLT);console.log(BOLT.response.txnStatus);},catchException:function(BOLT){console.log(BOLT);alert(BOLT.message);}});</script></body></html>");

            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = (int)System.Net.HttpStatusCode.OK,
                Content = sbHtml.ToString()
            };
        }

        [HttpGet("pay/checkout-launch/v2")]
        [AllowAnonymous]
        public ContentResult GetPayUHtmlV2()
        {
            byte[] hash;
            var data = new { key = "KTiotDpI", txnid = "T124", amount = 12.75, prodInfo = "My G Product", fname = "Grs", email = "meetgirish.mjn@gmail.com", mobile = "8871384762", udf5 = "", salt = "uc85JO4T0G" };
            string d = data.key + "|" + data.txnid + "|" + data.amount + "|" + data.prodInfo + "|" + data.fname + "|" + data.email + "|||||" + data.udf5 + "||||||" + data.salt;
            var datab = Encoding.UTF8.GetBytes(d);
            using (var shaM = new System.Security.Cryptography.SHA512Managed())
            {
                hash = shaM.ComputeHash(datab);
            }
            var hashStr = getHashString(hash);

            var sbHtml = new StringBuilder();
            var logoUrl = AppConfig.ImageSrcEndpoint + "app/logo_light_sm.png";

            var launchStr = string.Format("key:'{0}',txnid:'{1}',hash:'{2}',amount:{3},firstname:'{4}',email:'{5}',phone:'{6}',productinfo:'{7}',udf5:'{8}',surl:'{9}',furl:'{10}'", data.key, data.txnid, hashStr, data.amount, data.fname, data.email, data.mobile, data.prodInfo, data.udf5, AppConfig.CoreApiEndpoint + "merchant/pay/callback/success", AppConfig.CoreApiEndpoint + "merchant/pay/callback/failure");
            sbHtml.Append("<!DOCTYPE html><html lang=\"en\"><head><title>Portal-Shun#Q</title><meta charset=\"utf-8\"><meta name=\"viewport\" content=\"width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no\"> <script id=\"bolt\" src=\"https://sboxcheckout-static.citruspay.com/bolt/run/bolt.min.js\" bolt-color='#0173CF' bolt-logo='" + logoUrl+"'></script> <style> </style></head><body><script type=\"text/javascript\"> bolt.launch({"+launchStr+"}, { responseHandler: function (BOLT) { console.log('success'); console.log(BOLT); }, catchException: function (BOLT) { console.log('catchException');console.log(BOLT); alert(BOLT.message); } });</script></body></html>");

            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = (int)System.Net.HttpStatusCode.OK,
                Content = sbHtml.ToString()
            };
        }

        public InitPayUViewModel InitPayU(string authToken)
        {
            var service = CreateStoreService();
            var user = CreateMembershipService().GetUserSession(authToken);
            if (user == null)
                throw new Exception("Session expired. Try again.");

            var tokens = this.AppConfig.MerchangePaymentTokenTest.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            var cart = service.GetCart(user.Id);
            if (cart == null)
                throw new BusinessException("Cart does not exist or  cart is already checked-out");

            if (cart.NetAmount <= 0)
                throw new BusinessException("Invalid net-amount in Cart");

            var salt = tokens[1];

            
            CurrentUser = new UserInfo
            {
                FullName = user.FullName,
                MobileNumber = user.MobileNumber,
                Email = user.Email
            };

            var vm = new InitPayUViewModel()
            {
                IsDebug = true,
                Key = tokens[0],
                Amount = cart.NetAmount,
                Email = CurrentUser.Email,
                Phone = CurrentUser.MobileNumber,
                firstName = CurrentUser.FullName,
                TxnId = cart.Id,
                ProductName = "Shop at " + cart.StoreName,
                udf1 = "u1",
                udf2 = "u2",
                udf3 = "u3",
                udf4 = "u4",
                udf5 = "u5",
                surl = AppConfig.CoreApiEndpoint + "merchant/pay/callback/success",
                furl = AppConfig.CoreApiEndpoint + "merchant/pay/callback/failure",
                ColorCode = "#0173CF",
                LogoUrl = AppConfig.ImageSrcEndpoint + "app/logo_light_sm.png"
            };

            string shaIn = $"{vm.Key}|{vm.TxnId}|{vm.Amount}|{vm.ProductName}|{vm.firstName}|{vm.Email}|{vm.udf1}|{vm.udf2}|{vm.udf3}|{vm.udf4}|{vm.udf5}||||||{salt}";

            var shaBytes = Encoding.UTF8.GetBytes(shaIn);
            using (var shaM = new System.Security.Cryptography.SHA512Managed())
            {
                var hash = shaM.ComputeHash(shaBytes);
                vm.HashCode = getHashString(hash);
            }

            return vm;
        }

        private bool isPayUResponseHashValidated()
        {
            // before  sha512(key|txnid|amount|productinfo|firstname|email|udf1|udf2|udf3|udf4|udf5||||||SALT)
            // after   sha512(SALT|status||||||udf5|udf4|udf3|udf2|udf1|email|firstname|productinfo|amount|txnid|key) 

            return true;
        }

        [HttpGet("pay/checkout-launch/v3/{authToken}")]
        [AllowAnonymous]
        public ContentResult GetPayUHtmlV3(string authToken)
        {
            var html = string.Empty;
            try
            {
                // var html = System.IO.File.ReadAllText(@"C:\Users\gmaha\OneDrive - Monsanto\pau_Index.html");
                html = "<!DOCTYPE html><html lang=\"en\"><head><title>Portal-Shun#Q</title><meta name=\"viewport\" content=\"width = device - width, initial - scale = 1, maximum - scale = 1, user - scalable = no\"><script id=\"bolt\" src=\"https://sboxcheckout-static.citruspay.com/bolt/run/bolt.min.js\" bolt-color=\"#0173CF\" bolt-logo=\"https://cdn0storage0shunq0dev.blob.core.windows.net/images/app/logo_light_sm.png\"></script></head><body class=\"menubar-hoverable header-fixed\"><form action=\"https://sandboxsecure.payu.in/_payment\" method=\"post\" id=\"testform\" name=\"testform\"><input type=\"hidden\" name=\"key\" value=\"__key__\"><input type=\"hidden\" name=\"firstname\" value=\"__firstname__\"><input type=\"hidden\" name=\"email\" value=\"__email__\"><input type=\"hidden\" name=\"phone\" value=\"__phone__\"><input type=\"hidden\" name=\"productinfo\" value=\"__productinfo__\"><input type=\"hidden\" name=\"udf1\" value=\"__udf1__\"><input type=\"hidden\" name=\"udf2\" value=\"__udf2__\"><input type=\"hidden\" name=\"udf3\" value=\"__udf3__\"><input type=\"hidden\" name=\"udf4\" value=\"__udf4__\"><input type=\"hidden\" name=\"udf5\" value=\"__udf5__\"><input type=\"hidden\" name=\"surl\" value=\"__surl__\"><input type=\"hidden\" name=\"furl\" value=\"__furl__\"><input type=\"hidden\" name=\"txnid\" value=\"__txnid__\"><input type=\"hidden\" name=\"hash\" value=\"__hash__\"><input type=\"hidden\" name=\"service_provider\" value=\"payu_paisa\"> <input type=\"hidden\" name=\"amount\" value=\"__amount__\"></form><script>document.testform.submit();</script></body></html>";

                var vm = InitPayU(authToken);

                html = html.Replace("__key__", vm.Key);
                html = html.Replace("__firstname__", vm.firstName);
                html = html.Replace("__email__", vm.Email);
                html = html.Replace("__phone__", vm.Phone);
                html = html.Replace("__productinfo__", vm.ProductName);
                html = html.Replace("__udf1__", vm.udf1);
                html = html.Replace("__udf2__", vm.udf2);
                html = html.Replace("__udf3__", vm.udf3);
                html = html.Replace("__udf4__", vm.udf4);
                html = html.Replace("__udf5__", vm.udf5);
                html = html.Replace("__surl__", vm.surl);
                html = html.Replace("__furl__", vm.furl);
                html = html.Replace("__txnid__", vm.TxnId);
                html = html.Replace("__hash__", vm.HashCode);
                html = html.Replace("__amount__", vm.Amount + "");


            }
            catch (Exception ex)
            {
                html = "<b>" + ex.Message + "</b>";
            }
            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = (int)System.Net.HttpStatusCode.OK,
                Content = html
            };
        }
    }
}
