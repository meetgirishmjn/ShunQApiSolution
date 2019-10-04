using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessCore;
using BusinessCore.AppHandlers;
using BusinessCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TelementryApi.RequestModels;

namespace TelementryApi.Controllers
{
    [Route("api/v1/cart")]
    [ApiController]
    public class CartDeviceController : BaseController
    {
        public CartDeviceController(IServiceProvider serviceProvider, IOptions<AppConfig> appConfig) : base(serviceProvider, appConfig)
        {

        }

        [HttpPost("item/add")]
        public async Task<ActionResult> ItemAdded([FromBody]ItemAddedModel model)
        {
            var appId = ReadAppId();
            var deviceId = ReadDeviceId();

            var service = CreateStoreService();

            var arg = new CartDeviceEventArg();
            arg.AppId = appId;
            arg.DeviceId = deviceId;
            arg.CartId = model.CartId;
            arg.CartWeight = model.CartWeight;
            arg.ProductId = model.ItemCode;
            
            await service.CartDeviceProductAddedAsync(arg);

            return Ok("Event logged successfully. Event-Id: "+arg.Id);
        }


        [HttpPost("item/remove")]
        public async Task<ActionResult> ItemRemoved([FromBody]ItemAddedModel model)
        {
            var appId = ReadAppId();
            var deviceId = ReadDeviceId();

            var service = CreateStoreService();

            var arg = new CartDeviceEventArg();
            arg.AppId = appId;
            arg.DeviceId = deviceId;
            arg.CartId = model.CartId;
            arg.CartWeight = model.CartWeight;
            arg.ProductId = model.ItemCode;

            await service.CartDeviceProductRemovedAsync(arg);

            return Ok("Event logged successfully. Event-Id: " + arg.Id);
        }
    }
}
