namespace MauiApp1;

public partial class Person : ContentPage
{
	public Person()
	{
		InitializeComponent();
	}

    private void btnSave_Clicked(object sender, EventArgs e)
    {
		string msg = $"Name:{FirstName.Text}\n LastName:{LastName.Text}\n Email:{Email.Text}";
		DisplayAlert("Info",msg,"Done");

    }
}