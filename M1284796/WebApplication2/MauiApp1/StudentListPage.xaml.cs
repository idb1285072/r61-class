
using MauiApp1.DTOs;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace MauiApp1;

public partial class StudentListPage : ContentPage
{
    public ObservableCollection<StudentDto> StudentList { get; set; } = new ObservableCollection<StudentDto>();

    public StudentListPage()
	{
		InitializeComponent();
        BindingContext=this;
        _ = LoadStudent();
	}

    private async Task LoadStudent()
    {
        using var client = new HttpClient
        {
            BaseAddress = new Uri(DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5000" : "http://localhost:5000")
        };

    
        var res = await client.GetAsync("/api/stu");

        if (res.IsSuccessStatusCode)
        {
           var content=await res.Content.ReadAsStringAsync();
            var student=JsonSerializer.Deserialize<ObservableCollection<StudentDto>>
                (content, new JsonSerializerOptions { PropertyNameCaseInsensitive=true});

            if (student !=null)
            {
                StudentList=student;
                StudentViewList.ItemsSource=StudentList;

            }
            else
            {
                await DisplayAlert("Error", "Error Occured", "Ok");
            }
        }
       

    }

    //private void AddStudentBtn(object sender, EventArgs e)
    //{

    //}

    //private async void DeleteStudentBtn(object sender, EventArgs e)
    //{
    //    if (sender is Button button && button.CommandParameter is StudentDto studentDto)
    //    {
    //        bool result = await DisplayAlert("Delete",$"Delete Student {studentDto.Name}", "Yes","No");

    //        if (result)
    //        {
    //            using var client = new HttpClient
    //            {
    //                BaseAddress = new Uri(DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5000" : "http://localhost:5000")
    //            };

    //            var res = await client.DeleteAsync($"/api/stu/{studentDto.Id}");

    //            if (res.IsSuccessStatusCode)
    //            {
    //                await DisplayAlert("Success", "Deleted", "Ok");
    //                await Navigation.PushAsync(new StudentListPage());
    //            }
    //            else
    //            {
    //                await DisplayAlert("Error", "Error Occured", "Ok");
    //            }
    //        }
    //    }
    //}

    private void AddStudentBtn(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AddStudentPage());

    }

    private async void DeleteStudentBtn(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is StudentDto studentDto)
        {
            bool result = await DisplayAlert("Delete", $"Delete Student {studentDto.Name}", "Yes", "No");

            if (result)
            {
                using var client = new HttpClient
                {
                    BaseAddress = new Uri(DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5000" : "http://localhost:5000")
                };

                var res = await client.DeleteAsync($"/api/stu/{studentDto.Id}");

                if (res.IsSuccessStatusCode)
                {
                    await DisplayAlert("Success", "Deleted", "Ok");
                    await Navigation.PushAsync(new StudentListPage());
                }
                else
                {
                    await DisplayAlert("Error", "Error Occured", "Ok");
                }
            }
        }
    }

    private void OnStudentUpdateClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is StudentDto student)
        {
            Navigation.PushAsync(new UpdateStudentPage(student.Id));
        }
    }
}