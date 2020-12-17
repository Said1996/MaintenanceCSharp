using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class ClientDevice
    {
        public int Id { get; set; }

        public bool Done { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public int Price { get; set; }

        public string DeviceStatus { get; set; }

        public string Problem { get; set; }

        public string ReceivingTime { get;  set; }

        public string DelieviredTime { get; set; }

        public string RecieverEmployee { get; set; }

        public string DelivererEmployee { get; set; }
    }
}
