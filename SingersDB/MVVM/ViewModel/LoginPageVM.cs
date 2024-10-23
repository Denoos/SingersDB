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
                Application.Current.MainPage.DisplayAlert("Social Credit", "Вы не тот, кем называетесь (ㆆ_ㆆ)", "ок");
            else
            {
                if (await dataBase.Authorization(User.Name, User.Password))
                    //Shell.Current.GoToAsync("//ListPage");
                    User.Name = "true"; // заглушка на условие до готовности страницы
                else Application.Current.MainPage.DisplayAlert("Social Credit", "Вы не тот, кем называетесь (ㆆ_ㆆ)", "ок");
            }
        }
    }
}
