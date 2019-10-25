using BusinessCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelementryApi.ResponseModels
{
    public class VersionViewModel
    {
        public string Version { get; set; }
        public string VersionDesc { get; set; }
        public string Status { get; set; }
        public string DbStatus { get; set; }
        public string CacheStatus { get; set; }
        public AppConfig AppConfig { get; set; }

        public dynamic OS { get; set; }
    }
}
