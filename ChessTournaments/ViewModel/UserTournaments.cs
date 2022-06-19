using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournaments.ViewModel
{
    using Model;
    using DAL.Encje;
    using View;
    using System.Windows;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    class UserTournaments : TournamentListViewModel
    {
        DashboardViewModel Parent { get; set; }
        public Zawodnik ZalogowanyZawodnik { get; set; }
        public UserTournaments()
        {
            model = new TurniejModel();
            OdswiezTurnieje();
        }

        public UserTournaments(DashboardViewModel parent)
        {
            Parent = parent;
            model = new TurniejModel();
            LoginScreen loginScreen = Application.Current.MainWindow as LoginScreen;
            Uzytkownik uzytkownik = loginScreen.loginViewModel.ZalogowanyUzytkownik;
            ZalogowanyZawodnik = new Zawodnik(uzytkownik.Login);
            OdswiezTurnieje(ZalogowanyZawodnik);
        }

        private ICommand zaladujInformacjeOTurnieju;
        public ICommand ZaladujInformacjeOTurnieju => zaladujInformacjeOTurnieju ?? (zaladujInformacjeOTurnieju =
            new RelayCommand(
                o =>
                {
                    Turniej wybranyTurniej = WybranyTurniej;
                    if (wybranyTurniej != null && Parent != null)
                        Parent.WypelnijFormularzZObiektu(wybranyTurniej);
                },
                null
                ));
        public void OdswiezTurnieje(Zawodnik zawodnik)
        {
            ObservableCollection<Turniej> pobraneTurnieje = model.PobierzWszystkieTurniejeuzytkownika(zawodnik);
            if (!pobraneTurnieje.Equals(Turnieje))
            {
                Turnieje = pobraneTurnieje;
            }

        }

        public new Turniej WybranyTurniej
        {
            get => wybranyTurniej;
            set
            {
                wybranyTurniej = value;
                onPropertyChanged(nameof(wybranyTurniej));
                ZaladujInformacjeOTurnieju.Execute(this);

            }
        }


    }

}
