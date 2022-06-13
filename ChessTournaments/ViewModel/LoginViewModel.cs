using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using ChessTournaments.Model;

namespace ChessTournaments.ViewModel
{
    using View;
    using Model;
    using DAL.Encje;
    using BaseClasses;
    class LoginViewModel:AuthenticationViewModel
    {
        private LoginModel _loginModel = new LoginModel();

        private void CzyscFormularz(LoginScreen loginScreen)
        {
            Login = null;
            loginScreen.PasswordTextBox.Password = null;
            Haslo = null;
            
        }

        private ICommand loginUser;
        public ICommand LoginUser => loginUser ?? (loginUser =
            new RelayCommand(
                o =>
                {
                    LoginScreen loginScreen = o as LoginScreen;

                    bool czy_istnieje = _loginModel.WeryfikujUzytkownika(new Uzytkownik(Login, Haslo));
                    if (czy_istnieje)
                    {
                        MessageBox.Show($"Pomyślnie zalogowano jako {Login}");
                        Uzytkownik.TypyKont typKonta = _loginModel.PobierzTypKonta(Login);
                        if(typKonta == Uzytkownik.TypyKont.ORGANIZATOR)
                        {
                            OrganizerDashboard organizerDashboard = new OrganizerDashboard();
                            organizerDashboard.Show();
                        }
                        else if (typKonta == Uzytkownik.TypyKont.ZAWODNIK)
                        {
                            PlayerDashboard playerDashboard = new PlayerDashboard();
                            playerDashboard.Show();
                        }
                        loginScreen.Close();
                    }
                    else
                    {
                        MessageBox.Show("Błędny login lub hasło");
                    }
                    CzyscFormularz(loginScreen);
                },
                o => (Login != null) && (Haslo != null)
                ));

        private ICommand goToRegisterScreen;
        public ICommand GoToRegisterScreenEvent => goToRegisterScreen ?? (goToRegisterScreen =
            new RelayCommand(
                o =>
                {
                    RegisterScreen registerScreen = new RegisterScreen();                    
                    LoginScreen loginScreen = o as LoginScreen;
                    registerScreen.Show();
                    loginScreen.Close();

                },
                null));


    }
}
