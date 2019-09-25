using DynamicExpresso;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore.DataAccess.DbModels
{
   public class DiscountVoucherMaster
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Expression { get; set; }

        public float Apply(float amount)
        {
            var result = 0f;
            if (Expression == null)
                return result;
            if (Expression.Trim() == string.Empty)
                return result;

            var interpreter = new Interpreter();

            var array = Expression.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var exp in array)
            {
                if (result > 0)
                    break;
                if (exp.Trim().Length != 0)
                {
                    result = interpreter.Eval<float>(exp, new Parameter("amount", amount));
                }
            }
            return result;
        }

        public bool TryApply(float amount,out float result)
        {
            var flag = true;
            result = 0;
            try
            {
                result = this.Apply(amount);
                if (result <= 0)
                {
                    result = 0;
                    flag = false;
                }
            }
            catch (Exception ex)
            {
                flag = false;
            }
            return flag;
        }
    }
}
