using Maui.Models;
using Microsoft.Maui.Controls.Platform;
namespace Maui.Pages;

public partial class Edit : ContentPage
{
    private readonly Student _student;

    public Edit(Student student)
    {
        InitializeComponent();
        _student = student;

        NameEntry.Text = _student.Name;
        AdmissionDatePicker.Date = _student.AdmissionDate;
        IsActiveSwitch.IsToggled = _student.IsActive;
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        string newName = NameEntry.Text?.Trim() ?? "";

        if (string.IsNullOrEmpty(newName))
        {
            await DisplayAlert("Validation", "Name is required.", "OK");
            return;
        }

        _student.Name = newName;
        _student.AdmissionDate = AdmissionDatePicker.Date;
        _student.IsActive = IsActiveSwitch.IsToggled;

        //await httpClient.PutAsJsonAsync($"api/students/{_student.Id}", _student);
        await Navigation.PopAsync();
    }
}