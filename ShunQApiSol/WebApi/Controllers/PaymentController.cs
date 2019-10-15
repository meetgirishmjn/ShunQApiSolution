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

        [HttpGet("pay/success")]
        public ActionResult<InitPaymentViewModel> OnPaymentSuccess()
        {
            var viewModel = new InitPaymentViewModel();
            return Ok(viewModel);
        }
        [HttpGet("pay/failure")]
        public ActionResult<InitPaymentViewModel> OnPaymentFailure()
        {
            var viewModel = new InitPaymentViewModel();
            return Ok(viewModel);
        }
    }
}
