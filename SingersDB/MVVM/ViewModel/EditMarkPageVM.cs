using SingersDB.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingersDB.MVVM.ViewModel
{
    [QueryProperty(nameof(Mark), "SelMark")]
    internal class EditMarkPageVM : BaseVM
    {
        public EditMarkPageVM()
        {
            Save = new VmCommand(async () => await Shell.Current.GoToAsync("//ListViewPage"));
            Back = new VmCommand(() => SaveAndBackMethod());
        }

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

        public VmCommand Save { get; set; }
        public VmCommand Back { get; set; }

        private async void SaveAndBackMethod()
        {
            Mark.LastUpdateDate = DateTime.Now;
            await DB.Instance.UpdateMark(Mark);
            await Shell.Current.GoToAsync("//ListViewPage");
        }
    }
}
