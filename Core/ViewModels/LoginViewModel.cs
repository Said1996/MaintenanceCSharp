using Core.Models;
using MvvmCross.Navigation;
using MvvmCross.Plugin.FieldBinding;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using System.Data.Entity;

namespace Core.ViewModels
{
    class LoginViewModel : MvxViewModel
    {


        public readonly IMvxNavigationService navigationService;
        
        private DeviceContext Context = new DeviceContext();
        
        public ObservableCollection<User> Users = new ObservableCollection<User>();

        public LoginViewModel(IMvxNavigationService mvxNavigationService)
        {
            navigationService = mvxNavigationService;
            Context.Users.Load();
            Users = Context.Users.Local;
        }

        public readonly INC<string> Email = new NC<string>();

        public readonly INC<string> Password = new NC<string>();

        public readonly INC<string> Error = new NC<string>();

        public async void SignIn()
        {
            var user = Users.FirstOrDefault(x => x.Email == Email.Value && x.Password == Password.Value);
            if (user == null)
                Error.Value = "Wrong Email or Password";
            else
                await navigationService.Navigate<MaintenanceViewModel>();
        }

        public async void SignUp()
        {

            await navigationService.Navigate<SignUpViewModel>();
        }
    }
}
