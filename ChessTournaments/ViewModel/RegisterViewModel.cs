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
    public class RegisterViewModel
    {
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
