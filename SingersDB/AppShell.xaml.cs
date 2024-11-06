using SingersDB.MVVM.View;
namespace SingersDB
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("AddMarkPage", typeof(AddMarkPage));
            Routing.RegisterRoute("AddPersonPage", typeof(AddPersonPage));
            Routing.RegisterRoute("EditMarkPage", typeof(EditMarkPage));
            Routing.RegisterRoute("EditPersonPage", typeof(EditPersonPage));
        }
    }
}
