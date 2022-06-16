using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Threading.Tasks;
using ChessTournaments.Model;

namespace ChessTournaments.ViewModel
{
    using View;
    using Model;
    using DAL.Encje;
    using BaseClasses;
    class RegisterViewModel : AuthenticationViewModel
    {

        private RegisterModel registerModel = new RegisterModel();


        private Visibility playerFormVisibility = Visibility.Collapsed;
        public Visibility PlayerFormVisibility 
        {
            get 
            {
                return playerFormVisibility;
            } 
            set
            {
                playerFormVisibility = value;
                onPropertyChanged(nameof(playerFormVisibility));
            }
        }

        private Visibility organizerFormVisibility = Visibility.Collapsed;
        public Visibility OrganizerFormVisibility
        {
            get
            {
                return organizerFormVisibility;
            }
            set
            {
                organizerFormVisibility = value;
                onPropertyChanged(nameof(organizerFormVisibility));
            }
        }


        private void CzyscFormularz(RegisterScreen registerScreen)
        {
            Login = null;
            registerScreen.PasswordTextBox.Password = null;
            Haslo = null;

            NazwaOrganizatora = null;

            ImieZawodnika = null;
            NazwiskoZawodnika = null;
            DataUrodzenia = DateTime.Now;
            PlecString = null;
            Ranking = 0;
            
        }




        private ICommand registerUser;
        public ICommand RegisterUser => registerUser ?? (registerUser =
            new RelayCommand(
                o =>
                {
                    RegisterScreen registerScreen = o as RegisterScreen;
                    var uzytkownik = new Uzytkownik(Login, Haslo, TypKonta);
                    registerModel.DodajUzytkownikaDoBazy(uzytkownik);

                    switch (uzytkownik.TypKonta)
                    {
                        case Uzytkownik.TypyKont.ORGANIZATOR:
                            var organizator = new Organizator(NazwaOrganizatora, uzytkownik.Login);
                            registerModel.DodajOrganizatoraDoBazy(organizator);
                            break;
                        case Uzytkownik.TypyKont.ZAWODNIK:
                            if (PlecString.Contains("Mężczyzna"))
                            {
                                Plec = 'M';
                            }
                            else
                            {
                                Plec = 'K';
                            }
                            var zawodnik = new Zawodnik(ImieZawodnika, NazwiskoZawodnika, new Date(DataUrodzenia), Plec, Ranking, uzytkownik.Login);
                            registerModel.DodajZawodnikaDoBazy(zawodnik);
                            break;
                    }

                    MessageBox.Show("Pomyślnie dodano użytkownika do bazy");
                    CzyscFormularz(registerScreen);

                },
                o => (Login != null) && (Haslo != null) && (TypKontaString != null)
                ));

        private ICommand goToLoginScreen;
        public ICommand GoToLoginScreenEvent => goToLoginScreen ?? (goToLoginScreen =
            new RelayCommand(
                o =>
                {
                    LoginScreen loginScreen = new LoginScreen();
                    RegisterScreen registerScreen = o as RegisterScreen;
                    loginScreen.Show();
                    registerScreen.Close();

                },
                null));

        private ICommand comboBoxSelectionChanged;
        public ICommand ComboBoxSelectionChanged => comboBoxSelectionChanged ?? (comboBoxSelectionChanged =
            new RelayCommand(
                o =>
                {
                    registerModel.Przelacz(this,TypKontaString);
                },
                null
                ));
    }
}
