using SingersDB.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingersDB.MVVM.ViewModel
{
    public class RegisterPageVM : BaseVM
    {
        public RegisterPageVM()
        {
            TryReg = new VmCommand(() => TryRegister());
        }

        public VmCommand TryReg { get; set; }

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

        protected async void TryRegister()
        {
            DB dataBase = DB.Instance;
            if (User == null || User.Name == "" || User.Password == "")
                Application.Current.MainPage.DisplayAlert("Social Credit", "Вы чего-то не договариваете (ㆆ_ㆆ)", "ок");
            else
            {
                User = new();
                await dataBase.Registraition(User.Name, User.Password);
                await Shell.Current.GoToAsync("//LoginPage");
            }
        }
    }
}
