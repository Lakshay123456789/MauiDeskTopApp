using HandlebarsDotNet.Collections;
using MauiApp3.MVVM.Model;
using MauiApp3.MVVM.Views;
using MvvmHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MauiApp3.MVVM.ViewModel
{
  
    public class ServiceViewModel : ObservableObject
    {
        private HttpClient _Client;
        public ObservableList<Service> ServiceCollection;
      
        private ObservableList<Service> _serviceCollection;
        public ServiceViewModel()
        {
             ServiceCollection = new ObservableList<Service>();
        }

        public async Task<ObservableList<Service>> GetServicesAsync()
        {
            try
            {
                _Client = new HttpClient();
                var token = Preferences.Get("Token", "Default Value");
                string url = $"https://localhost:7090/api/Admin/getallService";
                _Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                var httpResponse = await _Client.GetAsync(url);
                if (httpResponse.IsSuccessStatusCode)
                {
                    var responseData = JsonConvert.DeserializeObject<ObservableList<Service>>(await httpResponse.Content.ReadAsStringAsync());
                    ServiceCollection = new ObservableList<Service>(responseData);
                 //   OnPropertyChanged(nameof(ServiceCollection));
                    return ServiceCollection;
                }
              
            }catch(Exception e)
            {
                Debug.Write(e.Message);
            }
            return ServiceCollection;
        }

        public async Task DeleteServiceAsync(Guid Id)
        {
            try
            {
                _Client = new HttpClient();
                var token = Preferences.Get("Token", "Default Value");
                string apiUrl = $"https://localhost:7090/api/Admin/DeleteProduct?Id={Id}";
                //   _Client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                _Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var httpResponse = await _Client.DeleteAsync(apiUrl);
         

                if (httpResponse.IsSuccessStatusCode)
                {
                    string result = await httpResponse.Content.ReadAsStringAsync();
                    Debug.WriteLine(result);
                  
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        public async Task<Service> GetServiceById(Guid Id)
        {
            var service = new Service();
            try
            {
                _Client = new HttpClient();
                var token = Preferences.Get("Token", "Default Value");
                string apiUrl = $"https://localhost:7090/api/Admin/GetProductById?id={Id}";
                _Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var httpResponse = await _Client.GetAsync(apiUrl);
                if(httpResponse.IsSuccessStatusCode)
                {
                    var responseData = JsonConvert.DeserializeObject<Service>(await httpResponse.Content.ReadAsStringAsync());
                    service = responseData;
                    return service;
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return service;
        }

        public async Task EditServiceAsync(Service service)
        {
            try
            {
                _Client = new HttpClient();
                var token = Preferences.Get("Token", "Default Value");
                _Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                string apiUrl = $"https://localhost:7090/api/Admin/UpdateProduct?Id={service.Id}";        
                var json = JsonConvert.SerializeObject(service);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _Client.PutAsync(apiUrl, content);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine(result);
                    //OnPropertyChanged(nameof(ServiceCollection));
                    //     await Shell.Current.GoToAsync(nameof(GetAllService));
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }


            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }

        }
    }
}
