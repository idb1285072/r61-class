using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Xml.Linq;
using MauiApp1.Models;

namespace MauiApp1.Pages;

public partial class ADDEditCategory : ContentPage
{
	CategoryDTO _categoryDTO;
	public ADDEditCategory(CategoryDTO categoryDTO)
	{
		InitializeComponent();
		_categoryDTO = categoryDTO;
		if (categoryDTO != null) { 
			Name.Text = categoryDTO.Name;
			Id.Text = _categoryDTO.ProductCategoryID.ToString();
		}
	}

    private  void btnSave_Clicked(object sender, EventArgs e)
    {
        SaveCategories();
		
    }
    private async void SaveCategories()
    {
        try
        {
            _categoryDTO.ProductCategoryID =int.Parse( Id.Text);
            _categoryDTO.Name = Name.Text;
            HttpClient client = new HttpClient();
            string BaseAddress = (DeviceInfo.Platform == DevicePlatform.Android ?
              "https://10.0.2.2:7115" : "https://localhost:7115") + "/ProductCategories";
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = null;
            if (_categoryDTO.ProductCategoryID > 0)
            {
                response =await client
            .PutAsJsonAsync(BaseAddress+"/"+_categoryDTO.ProductCategoryID, _categoryDTO);
            }
            else
            {
                response =await client
            .PostAsJsonAsync(BaseAddress, _categoryDTO);
            }
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                // await  Navigation.PopModalAsync();
                await Navigation.PopModalAsync();
                
            }
            else
            {
                DisplayAlert("Error", response.ReasonPhrase, "Ok");
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "Ok");
        }
        

    }

    private async void btnDel_Clicked(object sender, EventArgs e)
    {
        try
        {
            _categoryDTO.ProductCategoryID = int.Parse(Id.Text);
           
            HttpClient client = new HttpClient();
            string BaseAddress = (DeviceInfo.Platform == DevicePlatform.Android ?
              "https://10.0.2.2:7115" : "https://localhost:7115") + "/ProductCategories";
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = null;
            if (_categoryDTO.ProductCategoryID > 0)
            {
                response = await client
            .DeleteAsync(BaseAddress + "/" + _categoryDTO.ProductCategoryID);
          
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                await Navigation.PopModalAsync();
            }
            else
            {
                DisplayAlert("Error", response.ReasonPhrase, "Ok");
            }
            }
            else
            {
                DisplayAlert("Error", "ID Missing", "Ok");
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "Ok");
        }

    }
    private void btnclr_Clicked(object sender, EventArgs e)
    {
        Name.Text = "";
        Id.Text="0";

    }
    private async void btnback_Clicked(object sender, EventArgs e)
    {
        //await Navigation.PopModalAsync(false);
        await Navigation.PopModalAsync();
    }
}