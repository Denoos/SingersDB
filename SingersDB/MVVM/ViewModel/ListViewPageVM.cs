using SingersDB.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingersDB.MVVM.ViewModel
{
    class ListViewPageVM : BaseVM
    {
        public ListViewPageVM()
        {
            GetList();
            Add = new VmCommand(() => AddMark());
            Edit = new VmCommand(() => EditMark());
            Del = new VmCommand(() => DeleteMark());
        }

        private List<Marks> marks;
        public List<Marks> Marks
        {
            get => marks;
            set
            {
                marks = value;
                Signal();
            }
        }
        private Marks selMark;
        public Marks SelMark
        {
            get => selMark;
            set
            {
                selMark = value;
                Signal();
            }
        }

        public VmCommand Add { get; set; }
        public VmCommand Edit { get; set; }
        public VmCommand Del { get; set; }

        private async Task GetList()
            => Marks = await DB.Instance.GetAllMarks();

        private async Task AddMark()
        {
            var a = DB.Instance.GetAllPersons().Result;
            if (a == null || a.Count == 0 )
                Application.Current.MainPage.DisplayAlert("Внимание", "Список людей пуст, сначала добавте персону", "Ок");
            else
                await Shell.Current.GoToAsync("AddMarkPage");
        }
        private async Task EditMark()
        {
            if (SelMark != null)
                await Shell.Current.GoToAsync("../EditMarkPage", new ShellNavigationQueryParameters() { { "SelMark", SelMark } });
            else
                Application.Current.MainPage.DisplayAlert("Внимание", "Выберите заметку для редактирования", "Ок");
        }
        private async Task DeleteMark() => await DB.Instance.DeleteMark(SelMark);
    }
}
