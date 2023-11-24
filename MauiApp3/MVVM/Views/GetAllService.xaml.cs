using MauiApp3.MVVM.ViewModel;


namespace MauiApp3.MVVM.Views;

public partial class GetAllService : ContentPage
{
	private ServiceViewModel _serviceViewModel;
    private bool isDataLoaded = false;
    public GetAllService(ServiceViewModel serviceViewModel)
{
		InitializeComponent();
		_serviceViewModel = serviceViewModel;


	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
    
        if (!isDataLoaded)
        {
            await LoadServiceAsync();
            isDataLoaded = true;
        }
    }
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        isDataLoaded = false;
    }
    public async Task LoadServiceAsync()
	{
		var ListServices = await _serviceViewModel.GetServicesAsync();
        Service_Collection.ItemsSource = ListServices;
        //   BindingContext = ListServices;
        BindingContext = _serviceViewModel;

    }
    private async Task DeleteAsyncService(Guid Id)
    {
        await _serviceViewModel.DeleteServiceAsync(Id);
    }

    private async void Delete_Clicked(object sender,EventArgs e)
	{
		if(sender is Button button && button.CommandParameter is Guid Id)
		{
			var result = await DisplayAlert("Delete Service", "Are you Sure to Delete this Service ?", "Ok", "Cancel");
			if (result)
			{
				await DeleteAsyncService(Id);
	
               await LoadServiceAsync();
            } 

		}
	}

	private async void Edited_Clicked(object sender,EventArgs e)
	{
		if (sender is Button button && button.CommandParameter is Guid Id)
		{
			var service = await _serviceViewModel.GetServiceById(Id);
			if (service != null)
			{
                var navigationParameter = new Dictionary<string, object> { { "SelectedService", service }};

                await Shell.Current.GoToAsync($"GetOnlyService", navigationParameter);

            }
            else
			{
				await LoadServiceAsync();
			}
        }
    }
    private async void AddService_Clicked(object sender,EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddNewServiceView));
    }




}

   