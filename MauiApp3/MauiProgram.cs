using MauiApp3.MVVM.ViewModel;
using MauiApp3.MVVM.Views;

namespace MauiApp3;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.Services.AddScoped<LoginView>();
		builder.Services.AddScoped<ServiceViewModel>();
		builder.Services.AddScoped<GetAllService>();
	//	builder.Services.AddScoped<MainPage>();
		//builder.Services.AddScoped<PageViewModel>();
		return builder.Build();
	}
}
