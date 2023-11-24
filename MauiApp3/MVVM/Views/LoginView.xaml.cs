using MauiApp3.MVVM.ViewModel;

namespace MauiApp3.MVVM.Views;

public partial class LoginView : ContentPage
{
	public LoginView()
	{
		InitializeComponent();
		BindingContext = new LoginViewModel();
	}
}