using Core.Models;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Core.ViewModels
{
    public class GuestBookViewModel : MvxViewModel
    {
        public GuestBookViewModel()
        {
            AddGuestCommand = new MvxCommand(AddGuest);
        }

        public IMvxCommand AddGuestCommand { get; set; }

        public void AddGuest()
        {
            PersonModel p = new PersonModel
            {
                FirstName = FirstName,
                LastName = LastName
            };

            FirstName = string.Empty;
            LastName = string.Empty;

            People.Add(p);
        }

        public bool CanAddGuest => FirstName?.Length > 0 && LastName?.Length > 0;

        private ObservableCollection<PersonModel> _people = new ObservableCollection<PersonModel>();

        public ObservableCollection<PersonModel> People
        {
            get { return _people; }
            set { SetProperty(ref _people, value); }
        }

        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                SetProperty(ref _firstName, value);
                RaisePropertyChanged(() => FullName);
                RaisePropertyChanged(() => CanAddGuest);
            }
        }

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set
            {
                SetProperty(ref _lastName, value);
                RaisePropertyChanged(() => FullName);
                RaisePropertyChanged(() => CanAddGuest);
            }
        }

        public string FullName => $"{FirstName} {LastName}";
    }
}
