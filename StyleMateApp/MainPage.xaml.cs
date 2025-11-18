using StyleMateApp.Pages;

namespace StyleMateApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
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
        private async void Login_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
    }

}


