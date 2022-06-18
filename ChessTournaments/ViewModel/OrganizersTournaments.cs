using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;

namespace ChessTournaments.ViewModel
{
    using Model;
    using DAL.Encje;
    using View;
    

    class OrganizersTournaments:TournamentListViewModel
    {
        DashboardViewModel Parent { get; set; }
        public OrganizersTournaments()
        {
            model = new TurniejModel();
            LoginScreen loginScreen = Application.Current.MainWindow as LoginScreen;
            Uzytkownik uzytkownik = loginScreen.loginViewModel.ZalogowanyUzytkownik;
            Organizator organizator = new Organizator(uzytkownik.Login);
            OdswiezTurnieje(organizator);
        }

        public OrganizersTournaments(DashboardViewModel parent)
        {
            Parent = parent;
            model = new TurniejModel();
            LoginScreen loginScreen = Application.Current.MainWindow as LoginScreen;
            Uzytkownik uzytkownik = loginScreen.loginViewModel.ZalogowanyUzytkownik;
            Organizator organizator = new Organizator(uzytkownik.Login);
            OdswiezTurnieje(organizator);
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

        public void OdswiezTurnieje(Organizator organizator)
        {
            ObservableCollection<Turniej> pobraneTurnieje = model.PobierzTurniejeOrganizatora(organizator);
            if (!pobraneTurnieje.Equals(Turnieje))
            {
                Turnieje = pobraneTurnieje;
            }
            
        }

        
    }
}
