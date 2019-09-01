using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore.Models
{
   public class StoreReview
    {
        public int StoreId { get; set; }
        public float Value { get; set; }
        public float VoteCount { get; set; }
    }
}
