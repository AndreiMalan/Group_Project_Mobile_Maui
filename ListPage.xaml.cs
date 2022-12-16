namespace Proiect_Mobile_Maui_Onetiu_Malan;
using Proiect_Mobile_Maui_Onetiu_Malan.Models;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (CityList)BindingContext;
        slist.Date = DateTime.UtcNow;
        City selectedCity = (CityPicker.SelectedItem as City);
        slist.CityID = selectedCity.ID;
        await App.Database.SaveCityListAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (CityList)BindingContext;
        await App.Database.DeleteCityListAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DestinationPage((CityList)
       this.BindingContext)
        {
            BindingContext = new Destination()
        });

    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var items = await App.Database.GetCitiesAsync();
        CityPicker.ItemsSource = (System.Collections.IList)items;
        CityPicker.ItemDisplayBinding = new Binding("CityDetails");
        var cityl = (CityList)BindingContext;

        listView.ItemsSource = await App.Database.GetListDestinationsAsync(cityl.ID);
    }

}