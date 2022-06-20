using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournaments.ViewModel
{

    using DAL.Encje;
    using Model;
    using View;
    using System.Collections.ObjectModel;
    using BaseClasses;
    using System.Windows;

    class PlayerListVewModel:ViewModelBase
    {
        public PlayerListVewModel()
        {
            
            LoginScreen loginScreen = Application.Current.MainWindow as LoginScreen;
            Uzytkownik uzytkownik = loginScreen.loginViewModel.ZalogowanyUzytkownik;
            ZalogowanyOrganizator = new Organizator(uzytkownik.Login);
            model = new ZgloszeniaModel(ZalogowanyOrganizator);
            OdswiezZgloszenia();
        }
        ZgloszeniaModel model;
        public Organizator ZalogowanyOrganizator { get; set; }

        public Zgloszenie WybraneZgloszenie { get; set; }

        private ObservableCollection<Zgloszenie> zgloszenia;
        public ObservableCollection<Zgloszenie> Zgloszenia
        {
            get => zgloszenia;
            set
            {
                zgloszenia = value;
                onPropertyChanged(nameof(zgloszenia));
               
            }
        }

        public void OdswiezZgloszenia()
        {
            ObservableCollection<Zgloszenie> pobraneZgloszenia = model.PobierzZgloszeniaOrganizatora(ZalogowanyOrganizator);
            if (!pobraneZgloszenia.Equals(Zgloszenia))
            {
                Zgloszenia = pobraneZgloszenia;
            }

        }
    }
}
