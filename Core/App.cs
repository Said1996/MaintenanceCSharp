﻿using Core.ViewModels;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<GuestBookViewModel>();
        }
    }
}
