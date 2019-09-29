using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore.Models
{
    public class ListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class CurrencyRef
    {
        public string Currency { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }

        public static CurrencyRef India
        {
            get
            {
                return new CurrencyRef
                {
                    Currency= "INR",
                    Symbol= "₹",
                    Name= "Indian Rupee"
                };
            }
        }
    }
}
