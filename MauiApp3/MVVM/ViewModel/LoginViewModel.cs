using MauiApp3.MVVM.Model;
using MauiApp3.MVVM.Model.ResponseModel;
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
    public class LoginViewModel : BaseViewModel
    {
        private LoginModel _loginModel;

        public LoginModel LoginModel
        {
            get => _loginModel ?? (_loginModel = new LoginModel());
            set
            {
                _loginModel = value;
                OnPropertyChanged(nameof(LoginModel));
            }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async  void OnLoginClicked()
        {
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(LoginModel, new ValidationContext(LoginModel), validationResults, true);

            if (isValid)
            {
                await CallLoginApi();
                // If CallLoginApi is successful, navigate to GetAllService
                await Shell.Current.GoToAsync(nameof(GetAllService));

            }
            else
            {
              
                var errorMessage = string.Join("\n", validationResults.Select(v => v.ErrorMessage));
      
              await  Application.Current.MainPage.DisplayAlert("Validation Error", errorMessage, "OK");
            }
        }

        private  async Task CallLoginApi()
        {
            try
            {
                string apiUrl = "https://localhost:7090/api/Authenticate/login";
                using (HttpClient client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(_loginModel);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        var responseData= JsonConvert.DeserializeObject<LoginResponseModel>(result);
                        Debug.WriteLine(responseData);
                        Preferences.Set("Token", responseData.Token);
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode}");
                    }
                }

            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
    }
}
