using StyleMateApp.Coontrols;
using Microsoft.Maui.Controls;

namespace StyleMateApp.Pages;


public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();

       
        
    }


    private async void AdicionarRoupa_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddRoupaPage());
    }

    private async void VerGuardaRoupa_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new GuardaRoupaPage());
    }

    private async void SugestaoOutfit_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SugestaoOutfitPage());
    }
}

