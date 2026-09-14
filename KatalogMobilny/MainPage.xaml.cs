namespace KatalogMobilny
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                Clicked.Text = $"Clicked {count} time";
            else
                Clicked.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(Clicked.Text);
        }
    }
}
// pierwsze 02,708 s 
// drugie 02,549 s