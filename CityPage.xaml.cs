namespace Proiect_Mobile_Maui_Onetiu_Malan;
using Proiect_Mobile_Maui_Onetiu_Malan.Models;
public partial class CityPage : ContentPage
{
	public CityPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var city = (City)BindingContext;
        await App.Database.SaveCityAsync(city);
        await Navigation.PopAsync();
    }
}