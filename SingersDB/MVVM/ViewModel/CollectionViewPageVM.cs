using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SingersDB.MVVM.Model;

namespace SingersDB.MVVM.ViewModel
{ 
    class CollectionViewPageVM : BaseVM
    {
        public CollectionViewPageVM()
        {
            GetList();
            Add = new VmCommand(() => AddPerson());
            Edit = new VmCommand(() => EditPerson());
            Del = new VmCommand(() => DeletePerson());
        }

        private List<Person> persons;
        public List<Person> Persons
        {
            get => persons;
            set
            {
                persons = value;
                Signal();
            }
        }
        private Person selPerson;
        public Person SelPerson
        {
            get => selPerson;
            set
            {
                selPerson = value;
                Signal();
            }
        }

        public VmCommand Add { get; set; }
        public VmCommand Edit { get; set; }
        public VmCommand Del { get; set; }

        private async Task GetList()
            => Persons = await DB.Instance.GetAllPersons();

        private async Task AddPerson() => await Shell.Current.GoToAsync("/AddPersonPage");
        private async Task EditPerson()
        {
            if (SelPerson != null)
                await Shell.Current.GoToAsync("../EditPersonPage", new ShellNavigationQueryParameters() { { "SelPerson", SelPerson } });
            else
                Application.Current.MainPage.DisplayAlert("Внимание", "Выберите персону для редактирования", "Ок");
        }
        private async Task DeletePerson() => await DB.Instance.DeletePerson(SelPerson);
    }
}
