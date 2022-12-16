using Proiect_Mobile_Maui_Onetiu_Malan.Models;

namespace Proiect_Mobile_Maui_Onetiu_Malan;

public partial class DestinationPage : ContentPage
{
    CityList cl;
    public DestinationPage(CityList clist)
    {
        InitializeComponent();
        cl = clist;
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var destination = (Destination)BindingContext;
        await App.Database.SaveProductAsync(destination);
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var destination = (Destination)BindingContext;
        await App.Database.DeleteProductAsync(destination);
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Destination d;
        if (listView.SelectedItem != null)
        {
            d = listView.SelectedItem as Destination;
            var ld = new ListDestination()
            {
                CityListID = cl.ID,
                DestinationID = d.ID
            };
            await App.Database.SaveListDestinationAsync(ld);
            d.ListDestinations = new List<ListDestination> { ld };
            await Navigation.PopAsync();
        }
    }
}