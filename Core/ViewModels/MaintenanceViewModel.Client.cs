using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ViewModels
{
    partial class MaintenanceViewModel
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _number;
        public string Number
        {
            get { return _number; }
            set { SetProperty(ref _number, value); }
        }

        private string _problem;
        public string Problem
        {
            get { return _problem; }
            set { SetProperty(ref _problem, value); }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set { SetProperty(ref _status, value); }
        }

        private int _price;
        public int Price
        {
            get { return _price; }
            set { SetProperty(ref _price, value); }
        }
    }
}
