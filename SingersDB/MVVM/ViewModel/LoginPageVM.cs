using SingersDB.MVVM.Model;
using System;
using System.Collections.Generic;
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
            /* if (await DataBase.Instance.Authorization(LoginAuth.Name, LoginAuth.Password))
                 Shell.Current.GoToAsync("//Changer");
             else DisplayAlert("Social Credit", "Вы не из нашей партии (ㆆ_ㆆ)", "ок"); */
        }
    }
}
