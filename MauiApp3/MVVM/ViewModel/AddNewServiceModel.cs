using MauiApp3.MVVM.Model;
using MauiApp3.MVVM.Views;
using MvvmHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace MauiApp3.MVVM.ViewModel
{
     public  class AddNewServiceModel:BaseViewModel
    {

        private ServiceDto _serviceDto;

        public ServiceDto ServiceDto
        {
            get =>  _serviceDto??(_serviceDto= new ServiceDto());
            set {
                _serviceDto = value;
                OnPropertyChanged(nameof(_serviceDto));
                }
        }
        public ICommand AddCommand { get; }
        public AddNewServiceModel()
        {
            AddCommand = new Command(OnClickedAdd);
        }

        private async void OnClickedAdd(object obj)
        {
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(ServiceDto, new ValidationContext(ServiceDto), validationResults, true);
            if(isValid) {


                await AddNewServiceAPI();

                await Shell.Current.GoToAsync(nameof(GetAllService));
            }
            else
            {
                var errorMessage = string.Join("\n", validationResults.Select(v => v.ErrorMessage));
                await Application.Current.MainPage.DisplayAlert("Validation Error", errorMessage, "OK");
            }
        }

        private async Task AddNewServiceAPI()
        {
            try
            {
                string apiUrl = "https://localhost:7090/api/Admin/AddNewProduct";
                var token = Preferences.Get("Token", "Default Value");
                using (HttpClient client = new HttpClient())
                {
                   client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var json = JsonConvert.SerializeObject(_serviceDto);

                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        // var responseData = JsonConvert.DeserializeObject<LoginResponseModel>(result);
                        Debug.WriteLine(result);

                        // Preferences.Set("Token", responseData.Token);
                    }
                    else
                    {

                        Console.WriteLine($"Error: {response.StatusCode}");
                    }
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
    }
}
