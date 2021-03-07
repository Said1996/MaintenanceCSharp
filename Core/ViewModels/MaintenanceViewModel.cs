using Core.Models;
using MvvmCross.Commands;
using MvvmCross.Plugin.FieldBinding;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Text;
using System.Windows.Input;

namespace Core.ViewModels
{
    partial class MaintenanceViewModel : MvxViewModel
    {
        public readonly INC<ObservableCollection<ClientDevice>> ClientDevices = new NC<ObservableCollection<ClientDevice>>();
        public readonly INC<ClientDevice> ClientDevice = new NC<ClientDevice>();
        public readonly INC<string> Name = new NC<string>();
        public readonly INC<string> Number = new NC<string>();
        public readonly INC<string> Problem = new NC<string>();
        public readonly INC<string> Status = new NC<string>();
        public readonly INC<int> Price = new NC<int>();
        public readonly INC<string> User = new NC<string>();

        public DeviceContext Context = new DeviceContext();

        public MaintenanceViewModel()
        {
            Context.ClientDevices.Load();

            ClientDevices.Value = Context.ClientDevices.Local;
        }

        private ICommand _addDevice;
        public ICommand AddDevice
        {
            get
            {
                _addDevice = _addDevice ?? new MvxCommand(AddingDevice);
                return _addDevice;
            }
        }

        public void AddingDevice()
        {
            var newDevice = new ClientDevice { Done = false, Name = Name.Value, ReceivingTime = DateTime.Now.ToString(), Price = Price.Value, RecieverEmployee = User.Value, DeviceStatus = Status.Value, PhoneNumber = Number.Value, Problem = Problem.Value };
            ClientDevices.Value.Add(newDevice);

            Context.SaveChanges();
        }

        private ICommand _deleteDevice;
        public ICommand DeleteDevice
        {
            get 
            {
                _deleteDevice = _deleteDevice ?? new MvxCommand(DeletingDevice);
                return _deleteDevice;
            }
        }


        public void DeletingDevice()
        {
            ClientDevices.Value.Remove(ClientDevice.Value);
            Context.SaveChanges();
        }


    }



    
}
