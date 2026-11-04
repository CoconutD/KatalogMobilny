namespace KatalogMobilny
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void PokazClicked(object sender, EventArgs e)
        {
            ZdjecieProduktu.IsVisible = true;
            EtykietaInfo.Text = "Wybrano myszkę";
        }

        private void UkryjClicked(object sender, EventArgs e)
        {
            ZdjecieProduktu.IsVisible = false;
            EtykietaInfo.Text = "Zdjęcie ukryte";
        }
    }
}
// pierwsze 02,708 s
// drugie 02,549 s
