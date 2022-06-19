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
            OdswiezZgloszenia(ZalogowanyOrganizator);
        }
        ZgloszeniaModel model;
        public Organizator ZalogowanyOrganizator { get; set; }

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

        public void OdswiezZgloszenia(Organizator organizator)
        {
            ObservableCollection<Zgloszenie> pobraneTurnieje = model.PobierzZgloszeniaOrganizatora(organizator);
            if (!pobraneTurnieje.Equals(Zgloszenia))
            {
                Zgloszenia = pobraneTurnieje;
            }

        }
    }
}
