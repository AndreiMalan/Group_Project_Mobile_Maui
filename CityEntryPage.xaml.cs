using Proiect_Mobile_Maui_Onetiu_Malan.Models;

namespace Proiect_Mobile_Maui_Onetiu_Malan;

public partial class CityEntryPage : ContentPage
{
	public CityEntryPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetCitiesAsync();
    }
    async void OnShopAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CityPage
        {
            BindingContext = new City()
        });
    }
    async void OnListViewItemSelected(object sender,
    SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new CityPage
            {
                BindingContext = e.SelectedItem as City
            });
        }
    }

}