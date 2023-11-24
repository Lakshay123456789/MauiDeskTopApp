using MauiApp3.MVVM.Views;
using Microsoft.Maui.Hosting;

namespace MauiApp3;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(LoginView),typeof(LoginView));
		Routing.RegisterRoute(nameof(GetAllService),typeof(GetAllService));
		Routing.RegisterRoute("GetOnlyService", typeof(MauiApp3.MVVM.Views.GetOnlyService));
		Routing.RegisterRoute("AddNewServiceView", typeof(AddNewServiceView));
	}
}
