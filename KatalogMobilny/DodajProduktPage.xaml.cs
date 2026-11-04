namespace KatalogMobilny
{
    public partial class DodajProduktPage : ContentPage
    {
        int iloscProduktow = 0;

        public DodajProduktPage()
        {
            InitializeComponent();
        }

        private void DodajClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PoleNazwa.Text))
            {
                EtykietaWyniku.Text = "Wpisz nazwę produktu!";
                return;
            }

            if (ListaKategorii.SelectedItem == null)
            {
                EtykietaWyniku.Text = "Wybierz kategorię!";
                return;
            }

            iloscProduktow++;

            string nazwa = PoleNazwa.Text;
            string kategoria = ListaKategorii.SelectedItem.ToString();

            EtykietaWyniku.Text = "Dodano: " + nazwa + " (" + kategoria + "), cena: " + PoleCena.Text + " zł. Razem produktów: " + iloscProduktow;
        }

        private void WyczyscClicked(object sender, EventArgs e)
        {
            iloscProduktow = 0;
            PoleNazwa.Text = "";
            PoleCena.Text = "";
            ListaKategorii.SelectedItem = null;
            EtykietaWyniku.Text = "Wyczyszczono, licznik = 0";
        }

        private void DostepnyZmieniony(object sender, ToggledEventArgs e)
        {
            if (e.Value == true)
            {
                EtykietaDostepny.Text = "Produkt dostępny";
            }
            else
            {
                EtykietaDostepny.Text = "Produkt niedostępny";
            }
        }

        private void NazwaZmieniona(object sender, TextChangedEventArgs e)
        {
            int ileZnakow = e.NewTextValue.Length;
            EtykietaWyniku.Text = "Nazwa ma " + ileZnakow + " znaków";
        }

        private void KategoriaZmieniona(object sender, EventArgs e)
        {
            if (ListaKategorii.SelectedItem == null)
            {
                return;
            }

            EtykietaWyniku.Text = "Kategoria: " + ListaKategorii.SelectedItem.ToString();
        }
    }
}
