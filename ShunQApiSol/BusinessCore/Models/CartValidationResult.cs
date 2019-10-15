using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore.Models
{
   public class CartValidationResult
    {
        public bool IsValid { get; set; } = false;
        public CartLogSummary CartSummary { get; set; }
        public List<string> Messages { get; set; }

        public CartValidationResult()
        {
            this.Messages = new List<string>();
        }
    }

    public class CartLogSummary
    {
        public int AddedItemCount { get; set; }
        public int RemovedItemCount { get; set; }
        public int NetItemCount { get; set; }
        public float CartWeight { get; set; }
        public string WeightUnit { get; set; }
    }
}
