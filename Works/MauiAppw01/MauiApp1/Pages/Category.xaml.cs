using MauiApp1.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace MauiApp1.Pages;

public partial class Category : ContentPage
{
	public Category()
	{
		InitializeComponent();
        LoadCategories();
	}
	private  void LoadCategories()
	{
        IEnumerable<CategoryDTO> allCat = new List<CategoryDTO>();
        try
        {
            HttpClient client = new HttpClient();
             
            string BaseAddress = (DeviceInfo.Platform == DevicePlatform.Android ?
              "https://10.0.2.2:7115" : "https://localhost:7115") + "/ProductCategories";
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client
            .GetAsync(BaseAddress).Result;
            response.EnsureSuccessStatusCode();
            allCat = response.Content.ReadFromJsonAsync
             <IEnumerable<CategoryDTO>>().Result;
        }
        catch (Exception ex)
        {
            DisplayAlert("Error",ex.Message,"Ok");
        }
        categryList.ItemsSource = allCat;
        
    }
    private async void categryList_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        //DisplayAlert("Data" ,((CategoryDTO)e.Item).Name,"Cancel");
      await  Navigation.PushModalAsync(new ADDEditCategory((CategoryDTO) e.Item));
    }

    private async void AddNew_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new ADDEditCategory(new CategoryDTO()));
    }
}