using Maui.Models;
using System.Net.Http.Json;

namespace Maui.Pages;

public partial class Create : ContentPage
{
	public Create()
	{
		InitializeComponent();
	}

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        try
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7134/")
            };
            Student std = new Student
            {
                Id = 0,
                Name= NameEntry.Text,
                AdmissionDate= AdmissionDatePicker.Date,
                IsActive=IsActiveSwitch.IsToggled
            };
            await httpClient.PostAsJsonAsync("api/students", std);
            await DisplayAlert("Yes", "Cretaed", "Ok");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Failed to load products: {ex.Message}", "OK");
        }
    }
}