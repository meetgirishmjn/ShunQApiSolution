using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessCore.DataAccess.DbModels
{
    public class CartDeviceMaster
    {
        [Key]
        public string CartDeviceId { get; set; }
        public int StoreMasterId { get; set; }
        public bool IsActive { get; set; }
        public string StatusRemark { get; set; }
        public StoreMaster Store { get; set; }
    }
}
