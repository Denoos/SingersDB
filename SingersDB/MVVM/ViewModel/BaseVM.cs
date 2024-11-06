using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SingersDB.MVVM.ViewModel
{
    public class BaseVM : INotifyPropertyChanged
    {
        public BaseVM() 
            => dataBase.BaseAddress = new Uri("https://192.200.1.1:7252/api/");
        protected void Signal([CallerMemberName] string prop = null)
           => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        public event PropertyChangedEventHandler? PropertyChanged;

        public readonly HttpClient dataBase = new();
    }
}