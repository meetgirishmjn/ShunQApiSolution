﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore
{
    public class AppConfig
    {
        public const string ADMIN_USER_NAME = "Admin";
        public string Environment { get; set; }
        public string CoreApiEndpoint { get; set; }
        public string ImageSrcEndpoint { get; set; }
        public bool AuthorizationEnabled { get; set; } = true;
        public bool LoggingEnabled { get; set; }
        public bool CachingEnabled { get; set; }
        public string RedisConnectionString { get; set; }
        public string LogStorageAccount { get; set; }
        public string RequestLogLevel { get; set; }
        
    }
}
        

