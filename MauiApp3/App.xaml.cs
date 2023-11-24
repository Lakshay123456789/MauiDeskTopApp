using MauiApp3.MVVM.Model;
using MauiApp3.MVVM.Views;

namespace MauiApp3;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
	MainPage = new AppShell();
	}
}
