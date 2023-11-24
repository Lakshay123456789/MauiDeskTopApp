using MauiApp3.MVVM.ViewModel;

namespace MauiApp3.MVVM.Views;

public partial class AddNewServiceView : ContentPage
{

	private AddNewServiceModel _addNewServiceModel;
    public AddNewServiceView()
	{
		InitializeComponent();
		_addNewServiceModel = new AddNewServiceModel();
		BindingContext = _addNewServiceModel;

	}


}