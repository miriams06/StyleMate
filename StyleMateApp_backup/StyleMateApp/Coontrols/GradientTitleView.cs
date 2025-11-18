namespace StyleMateApp.Coontrols
{
    public class GradientTitleView : ContentView
    {
        public GradientTitleView()
        {
            Content = new Frame
            {
                Padding = 20,
                CornerRadius = 0,
                HasShadow = false,
                Background = new LinearGradientBrush
                {
                    StartPoint = new Point(0, 0),
                    EndPoint = new Point(1, 0),
                    GradientStops =
                    {
                        new GradientStop { Color = Color.FromArgb("#7b4397"), Offset = 0 },
                        new GradientStop { Color = Color.FromArgb("#dc2430"), Offset = 1 }
                    }
                },
                Content = new Label
                {
                    Text = "StyleMate",
                    TextColor = Colors.White,
                    FontSize = 48,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    FontAttributes = FontAttributes.Bold
                }
            };
        }
    }
}
