using BusinessCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.ViewModels
{
    public class VersionViewModel
    {
        public string Version { get; set; }
        public string VersionDesc { get; set; }
        public string Status { get; set; }
        public string DbStatus { get; set; }
        public AppConfig AppConfig { get; set; }
        //public Dictionary<string,string> Values { get; set; }
    }
}
