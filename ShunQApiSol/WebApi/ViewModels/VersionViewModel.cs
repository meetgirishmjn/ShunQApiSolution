﻿using BusinessCore;
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
        public string CacheStatus { get; set; }
        public DateTime Date { get { return DateTime.Now; } }
        public AppConfig AppConfig { get; set; }

        public dynamic OS { get; set; }
        //public Dictionary<string,string> Values { get; set; }
    }
}
