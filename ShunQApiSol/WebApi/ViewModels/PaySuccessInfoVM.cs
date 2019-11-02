using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.ViewModels
{
    public class PaySuccessInfoVM
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public string CheckoutCode { get; set; }
    }

    public class PayUSuccessModel
    {
        public string mihpayid { get; set; }
        public string mode { get; set; }
        public string status { get; set; }
        public string key { get; set; }
        public string txnid { get; set; }
        public float amount { get; set; }
        public string addedon { get; set; }
        public string productinfo { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string udf1 { get; set; }
        public string udf2 { get; set; }
        public string udf3 { get; set; }
        public string udf4 { get; set; }
        public string udf5 { get; set; }
        public string udf6 { get; set; }
        public string udf7 { get; set; }
        public string udf8 { get; set; }
        public string udf9 { get; set; }
        public string udf10 { get; set; }
        public string hash { get; set; }
        public string field1 { get; set; }
        public string field2 { get; set; }
        public string field3 { get; set; }
        public string field4 { get; set; }
        public string field5 { get; set; }
        public string field6 { get; set; }
        public string field7 { get; set; }
        public string field8 { get; set; }
        public string field9 { get; set; }
        public string encryptedPaymentId { get; set; }
        public string bank_ref_num { get; set; }
        public string bankcode { get; set; }
        public string error_Message { get; set; }
        public string name_on_card { get; set; }
        public string cardnum { get; set; }
        public string payuMoneyId { get; set; }
        public float net_amount_debit { get; set; }
        public float discount { get; set; }

        public PayUSuccessModel ReadFrom(IFormCollection form)
        {
            var result = new PayUSuccessModel();
            var props = this.GetType().GetProperties();
            foreach(var key in form.Keys){
                var values= form[key];
                var value = values.FirstOrDefault();
                if (value==null)
                    continue;

                var prop = props.Where(o => o.Name.Equals(key, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                if (prop != null)
                {
                    prop.SetValue(result, Convert.ChangeType(value, prop.PropertyType),null);
                }
            }

            return result;
        }
    }
}
