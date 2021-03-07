using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ViewModels
{
    class SignUpViewModel : MvxViewModel
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

    }
}
