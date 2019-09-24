using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.ViewModels
{
    public class CheckoutViewModel
    {
        public bool IsCartValid { get; set; }
        public string ValidationCaption { get; set; }
        public string ValidationTitle { get; set; }
        public List<string> ValidationMessages { get; set; }
        public List<OfferCode> OfferCodes { get; set; }
        public List<LineItem> LineItems { get; set; }
        public int TotalLineItem { get; set; }
        public int TotalItem { get; set; }
        public float TotalAmount { get; set; }
        public float TotalDiscount { get; set; }
        public float OrderTotal { get; set; }

        public CheckoutViewModel()
        {
            this.LineItems = new List<LineItem>();
            this.OfferCodes = new List<OfferCode>();
            this.ValidationMessages = new List<string>();
        }

        public class OfferCode
        {
            public string Code { get; set; }
            public bool Status { get; set; }
            public string StatusMessage { get; set; }
        }

        public class LineItem
        {
            public string Id { get; set; }
            public string ImageUrl { get; set; }
            public string Title { get; set; }
            public string SubTitle { get; set; }
            public int Quantity { get; set; }
            public float Amount { get; set; }
            public float MRP { get; internal set; }
            public bool HasDiscount { get; internal set; }
        }
    }



}
