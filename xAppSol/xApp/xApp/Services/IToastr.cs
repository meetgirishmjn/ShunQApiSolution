﻿using System;
using System.Collections.Generic;
using System.Text;

namespace xApp.Services
{
    public interface IToastr
    {
        string GetDeviceId();
        void ShowError(string message);
    }
}
