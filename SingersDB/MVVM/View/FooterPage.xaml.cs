namespace SingersDB.MVVM.View;

public partial class FooterPage : ContentView
{
	public FooterPage()
	{
		InitializeComponent();
		BindingContext = this;
	}

    private async void exit(object sender, EventArgs e)
    {
		Shell.Current.FlyoutBehavior = FlyoutBehavior.Disabled;
		await Shell.Current.GoToAsync("//RegLog");
    }
}