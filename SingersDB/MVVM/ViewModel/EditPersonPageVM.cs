using SingersDB.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingersDB.MVVM.ViewModel
{
    [QueryProperty(nameof(Person), "SelPerson")]
    internal class EditPersonPageVM : BaseVM
    {
        public EditPersonPageVM()
        {
            Save = new VmCommand(async () => await Shell.Current.GoToAsync("//CollectionViewPage"));
            Back = new VmCommand(() => SaveAndBackMethod());
        }

        private Person person;
        public Person Person
        {
            get => person;
            set
            {
                person = value;
                Signal();
            }
        }

        public VmCommand Save { get; set; }
        public VmCommand Back { get; set; }

        private async void SaveAndBackMethod()
        {
            await DB.Instance.UpdatePerson(Person);
            await Shell.Current.GoToAsync("//CollectionViewPage");
        }
    }
}
