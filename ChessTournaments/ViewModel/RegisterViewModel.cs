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

        private RegisterModel _registerModel = new RegisterModel();
        

        private void CzyscFormularz(RegisterScreen registerScreen)
        {
            Login = null;
            registerScreen.PasswordTextBox.Password = null;
            Haslo = null;
            TypKontaString = null;
        }

        private ICommand registerUser;
        public ICommand RegisterUser => registerUser ?? (registerUser =
            new RelayCommand(
                o =>
                {
                    RegisterScreen registerScreen = o as RegisterScreen;
                    var uzytkownik = new Uzytkownik(Login, Haslo, TypKonta);
                    _registerModel.DodajUzytkownikaDoBazy(uzytkownik);
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
    }
}
