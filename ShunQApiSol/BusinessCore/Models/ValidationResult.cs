using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore.Models
{
   public class ValidationResult
    {
        public bool IsValid { get; set; } = false;
        public string Message { get; set; }

        public ValidationResult(string message)
        {
            this.IsValid = false;
            this.Message = message;
        }
    }
}
