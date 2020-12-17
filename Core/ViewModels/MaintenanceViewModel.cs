using Core.Models;
using MvvmCross.Commands;
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
        public DeviceContext Context = new DeviceContext();

        public MaintenanceViewModel()
        {
            Context.ClientDevices.Load();

            ClientDevices = Context.ClientDevices.Local;
        }

        private ObservableCollection<ClientDevice> _clientDevices;
        public ObservableCollection<ClientDevice> ClientDevices
        {
            get { return _clientDevices; }
            set { SetProperty(ref _clientDevices, value); }
        }

        private string _user;
        public string User
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }

        private ClientDevice _clientDevice;
        public ClientDevice ClientDevice
        {
            get { return _clientDevice; }
            set { SetProperty(ref _clientDevice, value); }
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

        private void AddingDevice()
        {
            var newDevice = new ClientDevice { Done = false, Name = Name, ReceivingTime = DateTime.Now.ToString(), Price = Price, RecieverEmployee = User, DeviceStatus = Status, PhoneNumber = Number, Problem = Problem };
            ClientDevices.Add(newDevice);

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

        private void DeletingDevice()
        {
            ClientDevices.Remove(ClientDevice);
            Context.SaveChanges();
        }

    }
}
