using Maui.Models;
using Maui.Services;
using System.Net.Http.Json;

namespace Maui.Pages;

public partial class Show : ContentPage
{
    private readonly StudentService std = new StudentService();
    public Show()
	{
		InitializeComponent();
        LoadDataAsync();
	}
    private async void LoadDataAsync()
    {
        //var products = await std.GetAsync();
        //stdList.ItemsSource = products;
        try
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7134/")
            };

            var std = await httpClient.GetFromJsonAsync<List<Student>>("api/students");

            stdList.ItemsSource = std ?? new List<Student>();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Failed to load products: {ex.Message}", "OK");
        }
    }   

    private void OnDeleteClicked(object sender, EventArgs e)
    {
        try
        {
            var httpCient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7134/")
            };

        }
        catch (Exception ex)
        {
            DisplayAlert("Error", $"Failed to delete {ex.Message}", "OK");
        }
    }

    private void OnEditClicked(object sender, EventArgs e)
    {

    }
}