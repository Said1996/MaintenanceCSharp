using Core.Models;
using MvvmCross.Navigation;
using MvvmCross.Plugin.FieldBinding;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Core.ViewModels
{
    class SignUpViewModel : MvxViewModel
    {
        public readonly IMvxNavigationService navigationService;

        private DeviceContext Context = new DeviceContext();

        public ObservableCollection<User> Users = new ObservableCollection<User>();

        public SignUpViewModel(IMvxNavigationService mvxNavigationService)
        {
            navigationService = mvxNavigationService;
            Context.Users.Load();
            Users = Context.Users.Local;
        }

        public readonly INC<string> Name = new NC<string>();

        public readonly INC<string> Email = new NC<string>();

        public readonly INC<string> Password = new NC<string>();

        public readonly INC<string> Error = new NC<string>();

        public async void SignIn()
        {
            await navigationService.Navigate<LoginViewModel>();
        }

        public async void SignUp()
        {
            var user = Users.FirstOrDefault(x => x.Name == Name.Value || x.Email == Email.Value);
            if (user == null)
                SignedUpCorrectly();
            else
                Error.Value = "Email or Username already exists.";
            
        }
        
        void SignedUpCorrectly()
        {
            Users.Add(new User() { Name = Name.Value, Email = Email.Value, Password = Password.Value });
            Name.Value = "";
            Email.Value = "";
            Password.Value = "";
            Error.Value = "Signed Up Successfully.";
            Context.SaveChanges();

        }

    }
}
