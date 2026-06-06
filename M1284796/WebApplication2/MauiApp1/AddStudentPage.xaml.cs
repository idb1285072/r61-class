using MauiApp1.DTOs;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.Json;

namespace MauiApp1;

public partial class AddStudentPage : ContentPage
{

    private StudentDto studentDto;
    private ImageSource pIS;

    public ObservableCollection<AddressDto>AddressList { get; set; }=new ObservableCollection<AddressDto>();
    public ImageSource PIS { get => pIS; set { pIS = value; OnPropertyChanged(); } }

    public AddStudentPage()
	{
		InitializeComponent();
        studentDto = new StudentDto();
        BindingContext = this;
	}

    private void AddAddressBtn(object sender, EventArgs e)
    {
        AddressList.Add(new AddressDto 
        { 
         City=EntryCity.Text,
         Street=EntryStreet.Text,
        });

        EntryCity.Text = "";
        EntryStreet.Text = "";
    }

    private async void UploadImageBtn(object sender, EventArgs e)
    {
        var result = await FilePicker.PickAsync(new PickOptions { PickerTitle="Select Image" });

        if (result!=null)
        {
            using var stream =await result.OpenReadAsync();
            using var memoryStram= new MemoryStream();
            await stream.CopyToAsync(memoryStram);
            byte[] data = memoryStram.ToArray();
            studentDto.BaseImage64=Convert.ToBase64String(data);
            PIS = ImageSource.FromFile(result.FullPath);
        }
    }

    private async void SaveStudentBtn(object sender, EventArgs e)
    {
        studentDto.Name=EntryName.Text;
        studentDto.AdmissionDate=AddDatePicker.Date;
        studentDto.IsActive=CheckBox.IsChecked;
        studentDto.ImageUrl=studentDto.BaseImage64;
        studentDto.Addresses=AddressList.ToList();
        studentDto.AddressJson=JsonSerializer.Serialize(AddressList);


        using var client = new HttpClient
        {
            BaseAddress = new Uri(DeviceInfo.Platform==DevicePlatform.Android ?  "http://10.0.2.2:5000" : "http://localhost:5000")
        };

        var content = new StringContent
        (
            System.Text.Json.JsonSerializer.Serialize(studentDto, new JsonSerializerOptions
            {            
                PropertyNamingPolicy=JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            }),Encoding.UTF8,"application/json"

        );
        var res = await client.PostAsync("/api/stu",content);

        if (res.IsSuccessStatusCode)
        {
            await DisplayAlert("Success", "Student Sreated", "Ok");
            await Navigation.PushAsync(new StudentListPage());
        }
        else
        {   
            await DisplayAlert("Error", "Error Occured", "Ok");
        }

    }
}