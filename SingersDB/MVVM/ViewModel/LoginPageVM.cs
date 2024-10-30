using SingersDB.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingersDB.MVVM.ViewModel
{
    public class LoginPageVM : BaseVM
    {
        public LoginPageVM()
        {
            TryAuth = new VmCommand(() => TryAuthentication());
        }

        public VmCommand TryAuth { get; set; }

        private User user = new();
        public User User
        {
            get => user;
            set
            {
                user = value;
                Signal();
            }
        }

        protected async void TryAuthentication()
        {
            DB dataBase = DB.Instance;
            if (User == null || User.Name == "" || User.Password == "")
                Application.Current.MainPage.DisplayAlert("Social Credit", "Вы чего-то не договариваете (ㆆ_ㆆ)", "ок");
            else
            {
                if (await dataBase.Authorization(User.Name, User.Password))
                {
                    User = new();
                    Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
                    await Shell.Current.GoToAsync("//CarouselView");
                }
                else Application.Current.MainPage.DisplayAlert("Social Credit", "Вы не тот, кем называетесь (ㆆ_ㆆ)", "ок");
            }
        }
    }
}
