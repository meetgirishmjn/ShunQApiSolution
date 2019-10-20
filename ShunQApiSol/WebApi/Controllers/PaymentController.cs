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

        [HttpPost("pay/init")]
        public ActionResult<InitPaymentViewModel> InitPayment(LogInModel model)
        {
            var viewModel = new InitPaymentViewModel();

            var service = CreateStoreService();

            var tokens = this.AppConfig.MerchangePaymentToken.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            var cart = service.GetCart();
            if (cart == null)
                throw new BusinessException("Cart does not exist");

            if (cart.NetAmount <= 0)
                throw new BusinessException("Invalid net-amount in Cart");

            var productInfo = "Purchase of " + cart.ItemCount;

            //String hashSequence = key | txnid | amount | productinfo | firstname | email | phone | udf1 | udf2 | udf3 | udf4 | udf5 |||||| salt;
            string hashSequence = tokens[0] + "|" + cart.Id + "|" + cart.NetAmount + "|" + productInfo + "|" + CurrentUser.FirstName + "|" + CurrentUser.Email + "|" + CurrentUser.MobileNumber + "| udf1 ||||||" + tokens[1];
            viewModel.HashCode = computeSha512Hash(hashSequence);

            return Ok(viewModel);
        }

        [HttpPost("pay/callback/success")]
        public ActionResult<InitPaymentViewModel> OnPaymentSuccess()
        {
            return Ok();
        }

        [HttpPost("pay/callback/failure")]
        public ActionResult<InitPaymentViewModel> OnPaymentFailure()
        {
            return Ok();
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
            var data = new { key = "KTiotDpI", txnid = "T124", amount = 12.75, prodInfo = "My G Product", fname = "Grs", email = "meetgirish.mjn@gmail.com",mobile="8871384762", udf5 = "", salt = "uc85JO4T0G" };
            string d = data.key + "|" + data.txnid + "|" + data.amount + "|" + data.prodInfo + "|" + data.fname + "|" + data.email + "|||||" + data.udf5 + "||||||" + data.salt;
            var datab = Encoding.UTF8.GetBytes(d);
            using (var shaM = new System.Security.Cryptography.SHA512Managed())
            {
                hash = shaM.ComputeHash(datab);
            }
            var hashStr = getHashString(hash);

            var sbHtml = new StringBuilder();
            var logoUrl = "https://image.freepik.com/free-vector/gradient-logo-template-with-abstract-shape_23-2148204210.jpg";

            var launchStr = string.Format("key:'{0}',txnid:'{1}',hash:'{2}',amount:{3},firstname:'{4}',email:'{5}',phone:'{6}',productinfo:'{7}',udf5:'{8}',surl:'{9}',furl:'{10}'", data.key, data.txnid, hashStr, data.amount, data.fname, data.email, data.mobile, data.prodInfo, data.udf5, AppConfig.CoreApiEndpoint + "merchant/pay/callback/success", AppConfig.CoreApiEndpoint + "merchant/pay/callback/failure");
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
    }
}
