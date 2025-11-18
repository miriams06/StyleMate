

namespace StyleMateApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }
        private void RegisterRoutes()
        {
            Routing.RegisterRoute(nameof(Pages.AddRoupaPage), typeof(Pages.AddRoupaPage));
            Routing.RegisterRoute(nameof(Pages.GuardaRoupaPage), typeof(Pages.GuardaRoupaPage));
            Routing.RegisterRoute(nameof(Pages.SugestaoOutfitPage), typeof(Pages.SugestaoOutfitPage));
        }
    }
}


