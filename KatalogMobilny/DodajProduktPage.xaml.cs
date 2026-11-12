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
            if (string.IsNullOrWhiteSpace(PoleNazwa.Text))
            {
                EtykietaWyniku.Text = "Wpisz nazwę produktu!";
                return;
            }

            if (double.TryParse(PoleCena.Text, out double cena) == false)
            {
                EtykietaWyniku.Text = "Zła cena!";
                return;
            }

            if (int.TryParse(PoleIlosc.Text, out int ilosc) == false)
            {
                EtykietaWyniku.Text = "Zła ilość!";
                return;
            }

            if (cena < 0 || ilosc < 0)
            {
                EtykietaWyniku.Text = "Cena i ilość nie mogą być mniejsze od 0!";
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
            double wartosc = cena * ilosc;

            EtykietaWyniku.Text = "Dodano: " + nazwa + " (" + kategoria + "), " + ilosc + " szt. po " + cena + " zł, razem " + wartosc + " zł. Produktów: " + iloscProduktow;
        }

        private void WyczyscClicked(object sender, EventArgs e)
        {
            iloscProduktow = 0;
            PoleNazwa.Text = "";
            PoleCena.Text = "";
            PoleIlosc.Text = "";
            PoleCena.BackgroundColor = Colors.Transparent;
            PoleIlosc.BackgroundColor = Colors.Transparent;
            ListaKategorii.SelectedItem = null;
            PrzelacznikDostepny.IsToggled = true;
            EtykietaWartosc.Text = "Wartość: 0 zł";
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

        private void LiczbaZmieniona(object sender, TextChangedEventArgs e)
        {
            Entry pole = (Entry)sender;

            if (double.TryParse(pole.Text, out double liczba))
            {
                if (liczba < 0)
                {
                    pole.BackgroundColor = Colors.Red;
                }
                else
                {
                    pole.BackgroundColor = Colors.LightGreen;
                }
            }
            else
            {
                pole.BackgroundColor = Colors.Transparent;
            }

            if (double.TryParse(PoleCena.Text, out double cena) && int.TryParse(PoleIlosc.Text, out int ilosc))
            {
                EtykietaWartosc.Text = "Wartość: " + (cena * ilosc) + " zł";
            }
            else
            {
                EtykietaWartosc.Text = "Wartość: 0 zł";
            }
        }
    }
}
