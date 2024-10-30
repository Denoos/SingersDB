using SingersDB.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingersDB.MVVM.ViewModel
{
    class AddMarkPageVM : BaseVM
    {
        public AddMarkPageVM()
        {
            Save = new VmCommand(async () => await Shell.Current.GoToAsync("//ListViewPage"));
            Back = new VmCommand(() => SaveAndBackMethod());
            GetPersonList();
            Mark.CreateDate = DateTime.Now;
            Mark.LastUpdateDate = DateTime.Now;
        }

        private async void GetPersonList() => Persons = await DB.Instance.GetAllPersons();

        private Marks marks;
        public Marks Mark
        {
            get => marks;
            set
            {
                marks = value;
                Signal();
            }
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

        public VmCommand Save { get; set; }
        public VmCommand Back { get; set; }

        private async void SaveAndBackMethod()
        {
            Person.Marks.Add(Mark);
            await DB.Instance.UpdatePerson(Person);
            await DB.Instance.AddMark(Mark);
            await Shell.Current.GoToAsync("//ListViewPage");
        }
    }
}
