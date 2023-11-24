using MauiApp3.MVVM.Model;
using MauiApp3.MVVM.ViewModel;
using System.Windows.Input;

namespace MauiApp3.MVVM.Views;

public partial class GetOnlyService : ContentPage, IQueryAttributable
{
    private Service _service;

    private ServiceViewModel _serviceViewModel;
    public GetOnlyService()
    {
        _serviceViewModel =  new ServiceViewModel();
        InitializeComponent();
        _service = new Service();
      
 
    }

   

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var selectedService = query["SelectedService"] as Service;
        if (selectedService != null)
        {
            _service = selectedService;
            BindingContext = _service;
          
        }
    }

    public async void OnEditClicked(object obj,EventArgs eventArgs)
    {


        string idText = IdEntry.Text;
        string title = ServiceTitle.Text;
        string description = ServiceDescription.Text;
        string priceText = ServicePrice.Text;
        string serviceTypeIdText = ServiceId.Text;

        if (Guid.TryParse(idText, out Guid id))
        {
            _service.Id = id;
        }

        if (decimal.TryParse(priceText, out decimal price))
        {
            _service.Price=price;
        }

        if (int.TryParse(serviceTypeIdText, out int serviceTypeId))
        {
            _service.ServieTypeId = serviceTypeId;
        }
        _service.Title = title;
        _service.Description = description;

        await _serviceViewModel.EditServiceAsync(_service);

        try
        {
              //  await Shell.Current.Navigation.PopToRootAsync();
             //   await Application.Current.MainPage.Navigation.PopToRootAsync();
            //    await Shell.Current.Navigation.PopModalAsync("");
            await Shell.Current.GoToAsync(nameof(GetAllService));
        }
        catch (Exception ex)
        {
          
            Console.WriteLine($"Navigation error: {ex.Message}");
        }
    }

  
}