using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SingersDB.MVVM.Model;

namespace SingersDB.MVVM.ViewModel
{
    class CarouselViewVM : BaseVM
    {
        public CarouselViewVM()
        {
            GetList();
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
        private async Task GetList()
            => Persons = await DB.Instance.GetAllPersons();
    }
}
